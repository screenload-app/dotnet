using System;
using System.Windows.Forms;
using Greenshot.Drawing;

namespace Greenshot
{
    public partial class SurfaceForm : Form
    {
        public SurfaceForm(Surface surface)
        {
            if (null == surface)
                throw new ArgumentNullException(nameof(surface));

            InitializeComponent();

            SuspendLayout();
            Controls.Add(surface);
            ResumeLayout(true);
        }
    }
}
