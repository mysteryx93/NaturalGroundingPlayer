﻿using System;

namespace HanumanInstitute.Downloads
{
    /// <summary>
    /// Represents the current status of a download.
    /// </summary>
    public enum DownloadStatus
    {
        Waiting,
        Initializing,
        Downloading,
        Done,
        Canceled,
        Failed
    }
}
