﻿//using System;
//using System.Threading.Tasks;
//using PropertyChanged;

//namespace HanumanInstitute.Downloads
//{
//    /// <summary>
//    /// Provides status updates of a download task.
//    /// </summary>
//    [AddINotifyPropertyChangedInterface()]
//    public class DownloadTaskStatus
//    {
//        /// <summary>
//        /// Occurs before performing the muxing operation.
//        /// </summary>
//        public event DownloadTaskEventHandler? BeforeMuxing;
//        /// <summary>
//        /// Occurus when progress information is updated.
//        /// </summary>
//        public event DownloadTaskEventHandler? ProgressUpdated;
//        /// <summary>
//        /// Gets or sets the title of the downloaded media.
//        /// </summary>
//        public string Title { get; set; } = string.Empty;
//        /// <summary>
//        /// Gets or sets the progress of all streams as percentage.
//        /// </summary>
//        public double ProgressValue { get; internal set; }
//        /// <summary>
//        /// Gets or sets the progress of all streams as a string representation.
//        /// </summary>
//        public string ProgressText { get; set; } = string.Empty;
//        /// <summary>
//        /// Gets or sets the download status.
//        /// </summary>
//        public DownloadStatus Status { get; internal set; } = DownloadStatus.Waiting;
//        /// <summary>
//        /// Cancels the download operation.
//        /// </summary>
//        public void Cancel()
//        {
//            if (Status != DownloadStatus.Success && Status != DownloadStatus.Failed)
//            {
//                Status = DownloadStatus.Canceled;
//            }
//        }

//        internal async Task OnBeforeMuxingAsync(DownloadTaskEventArgs e)
//        {
//            if (BeforeMuxing != null)
//            {
//                await Task.Run(() => BeforeMuxing(this, e)).ConfigureAwait(false);
//            }
//        }

//        internal void OnProgressUpdated(DownloadTaskEventArgs e) => ProgressUpdated?.Invoke(this, e);
//    }
//}
