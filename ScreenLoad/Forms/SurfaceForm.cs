using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenLoad.Drawing;
using ScreenLoad.Plugin;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public partial class SurfaceForm : Form
    {
        public Surface Surface { get; }

        public SurfaceForm(ICapture capture)
        {
            if (null == capture)
                throw new ArgumentNullException(nameof(capture));

            InitializeComponent();

            var captureCopy = new Capture((Image) capture.Image.Clone())
            {
                CaptureDetails = capture.CaptureDetails
            };

            var surface = new Surface(captureCopy)
            {
                CaptureDetails = capture.CaptureDetails,
                Modified = false
            };

            Surface = surface;

            SuspendLayout();
            Bounds = capture.ScreenBounds;
            Controls.Add(surface);
            ResumeLayout(true);
        }
    }
}