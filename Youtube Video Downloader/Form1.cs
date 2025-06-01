using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Youtube_Video_Downloader
{
    public partial class VideoDownloader : Form
    {
        private YoutubeClient youtube = new YoutubeClient();
        private StreamManifest streamManifest;
        private Video video;

        public VideoDownloader()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            cmbVideoQuality.Items.Clear();
            cmbAudioQuality.Items.Clear();

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("Please enter a YouTube URL.");
                return;
            }

            try
            {
                video = await youtube.Videos.GetAsync(txtUrl.Text);
                txtTitle.Text = video.Title;

                streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

                // For initial load, do nothing with video/audio combos here
                // We'll update video qualities based on selected file format

                var audioStreams = streamManifest.GetAudioOnlyStreams()
                    .OrderByDescending(s => s.Bitrate)
                    .ToList();

                foreach (var stream in audioStreams)
                {
                    cmbAudioQuality.Items.Add(string.Format("{0} kbps ({1})", stream.Bitrate.KiloBitsPerSecond, stream.Container.Name));
                }

                if (cmbAudioQuality.Items.Count > 0)
                    cmbAudioQuality.SelectedIndex = 0;

                this.cmbFileFormat.SelectedIndex = 0;  // triggers cmbFileFormat_SelectedIndexChanged and loads video streams accordingly
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading video: " + ex.Message);
            }
        }

        private void cmbFileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFileFormat.SelectedItem == null)
                return;

            string format = cmbFileFormat.SelectedItem.ToString();

            if (format == "mp3")
            {
                cmbVideoQuality.Items.Clear();
                cmbVideoQuality.Items.Add("Locked");
                cmbVideoQuality.SelectedIndex = 0;
                cmbVideoQuality.Enabled = false;
            }
            else if (format == "mp4")
            {
                cmbVideoQuality.Enabled = true;
                cmbVideoQuality.Items.Clear();

                if (streamManifest != null)
                {
                    var videoStreams = streamManifest.GetVideoOnlyStreams()
                        .Where(s => s.Container.Name == "mp4")
                        .OrderByDescending(s => s.VideoQuality.MaxHeight)
                        .ToList();

                    foreach (var stream in videoStreams)
                    {
                        cmbVideoQuality.Items.Add(string.Format("{0} ({1})", stream.VideoQuality.Label, stream.Container.Name));
                    }

                    if (cmbVideoQuality.Items.Count > 0)
                        cmbVideoQuality.SelectedIndex = 0;
                }
            }
            else if (format == "webm")
            {
                cmbVideoQuality.Enabled = true;
                cmbVideoQuality.Items.Clear();

                if (streamManifest != null)
                {
                    var muxedStreams = streamManifest.GetMuxedStreams()
                        .Where(s => s.Container.Name == "webm")
                        .OrderByDescending(s => s.VideoQuality.MaxHeight)
                        .ToList();

                    foreach (var stream in muxedStreams)
                    {
                        cmbVideoQuality.Items.Add(string.Format("{0} ({1})", stream.VideoQuality.Label, stream.Container.Name));
                    }

                    if (cmbVideoQuality.Items.Count > 0)
                        cmbVideoQuality.SelectedIndex = 0;
                }
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (video == null || streamManifest == null)
            {
                MessageBox.Show("Please load a video first.");
                return;
            }

            if (cmbFileFormat.SelectedItem == null)
            {
                MessageBox.Show("Please select a file format.");
                return;
            }

            string format = cmbFileFormat.SelectedItem.ToString();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = video.Title + "." + format;
                saveFileDialog.Filter = format.ToUpper() + " files|*." + format;

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string outputPath = saveFileDialog.FileName;

                progressBar.Value = 0;

                try
                {
                    if (format == "mp4")
                    {
                        // Existing mp4 logic: separate video + audio streams, then merge with ffmpeg
                        var videoStreams = streamManifest.GetVideoOnlyStreams()
                            .Where(s => s.Container.Name == "mp4")
                            .OrderByDescending(s => s.VideoQuality.MaxHeight)
                            .ToList();

                        if (videoStreams.Count == 0)
                        {
                            MessageBox.Show("No video-only mp4 streams available.");
                            return;
                        }

                        int videoIndex = cmbVideoQuality.SelectedIndex;
                        if (videoIndex < 0 || videoIndex >= videoStreams.Count)
                            videoIndex = 0;

                        var selectedVideoStream = videoStreams[videoIndex];

                        var audioStreams = streamManifest.GetAudioOnlyStreams()
                            .OrderByDescending(s => s.Bitrate)
                            .ToList();

                        if (audioStreams.Count == 0)
                        {
                            MessageBox.Show("No audio-only streams available.");
                            return;
                        }

                        int audioIndex = cmbAudioQuality.SelectedIndex;
                        if (audioIndex < 0 || audioIndex >= audioStreams.Count)
                            audioIndex = 0;

                        var selectedAudioStream = audioStreams[audioIndex];

                        string tempVideoFile = Path.GetTempFileName() + "." + selectedVideoStream.Container.Name;
                        string tempAudioFile = Path.GetTempFileName() + "." + selectedAudioStream.Container.Name;

                        await youtube.Videos.Streams.DownloadAsync(selectedVideoStream, tempVideoFile, new Progress<double>(p =>
                        {
                            progressBar.Invoke((Action)(() => progressBar.Value = (int)(p * 50)));
                        }));

                        await youtube.Videos.Streams.DownloadAsync(selectedAudioStream, tempAudioFile, new Progress<double>(p =>
                        {
                            progressBar.Invoke((Action)(() => progressBar.Value = 50 + (int)(p * 50)));
                        }));

                        string ffmpegArgs = string.Format("-y -i \"{0}\" -i \"{1}\" -c:v copy -c:a aac \"{2}\"", tempVideoFile, tempAudioFile, outputPath);
                        await RunFFmpegAsync(ffmpegArgs);

                        File.Delete(tempVideoFile);
                        File.Delete(tempAudioFile);
                    }
                    else if (format == "webm")
                    {
                        // New webm logic: download muxed stream (video+audio combined)
                        var muxedStreams = streamManifest.GetMuxedStreams()
                            .Where(s => s.Container.Name == "webm")
                            .OrderByDescending(s => s.VideoQuality.MaxHeight)
                            .ToList();

                        if (muxedStreams.Count == 0)
                        {
                            MessageBox.Show("No muxed webm streams available.");
                            return;
                        }

                        int muxedIndex = cmbVideoQuality.SelectedIndex;
                        if (muxedIndex < 0 || muxedIndex >= muxedStreams.Count)
                            muxedIndex = 0;

                        var selectedMuxedStream = muxedStreams[muxedIndex];

                        string tempFile = Path.GetTempFileName() + "." + selectedMuxedStream.Container.Name;

                        await youtube.Videos.Streams.DownloadAsync(selectedMuxedStream, tempFile, new Progress<double>(p =>
                        {
                            progressBar.Invoke((Action)(() => progressBar.Value = (int)(p * 100)));
                        }));

                        File.Copy(tempFile, outputPath, true);
                        File.Delete(tempFile);
                    }
                    else if (format == "mp3")
                    {
                        var audioStreams = streamManifest.GetAudioOnlyStreams()
                            .OrderByDescending(s => s.Bitrate)
                            .ToList();

                        if (audioStreams.Count == 0)
                        {
                            MessageBox.Show("No audio-only streams available.");
                            return;
                        }

                        int audioIndex = cmbAudioQuality.SelectedIndex;
                        if (audioIndex < 0 || audioIndex >= audioStreams.Count)
                            audioIndex = 0;

                        var selectedAudioStream = audioStreams[audioIndex];

                        string tempAudioFile = Path.GetTempFileName() + "." + selectedAudioStream.Container.Name;

                        await youtube.Videos.Streams.DownloadAsync(selectedAudioStream, tempAudioFile, new Progress<double>(p =>
                        {
                            progressBar.Invoke((Action)(() => progressBar.Value = (int)(p * 100)));
                        }));

                        string ffmpegArgs = string.Format("-y -i \"{0}\" -vn -b:a 192k \"{1}\"", tempAudioFile, outputPath);
                        await RunFFmpegAsync(ffmpegArgs);

                        File.Delete(tempAudioFile);
                    }

                    MessageBox.Show("Download completed!");
                    progressBar.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during download: " + ex.Message);
                }
            }
        }


        private Task RunFFmpegAsync(string arguments)
        {
            return Task.Run(async () =>
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    var outputTask = process.StandardOutput.ReadToEndAsync();
                    var errorTask = process.StandardError.ReadToEndAsync();

                    await Task.WhenAll(outputTask, errorTask);

                    process.WaitForExit();
                }
            });
        }

    }
}
