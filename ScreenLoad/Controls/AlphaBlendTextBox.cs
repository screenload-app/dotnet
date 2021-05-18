//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;

//namespace ScreenLoad.Controls
//{
//	/// <summary>
//	/// AlphaBlendTextBox: A .Net textbox that can be translucent to the background.
//	/// (C) 2003 Bob Bradley / ZBobb@hotmail.com
//	/// </summary>
//	public sealed class AlphaBlendTextBox : TextBox
//	{
//		private static class Native
//		{
//			public const int WM_MOUSEMOVE = 0x0200;
//			public const int WM_LBUTTONDOWN = 0x0201;
//			public const int WM_LBUTTONUP = 0x0202;
//			public const int WM_RBUTTONDOWN = 0x0204;
//			public const int WM_LBUTTONDBLCLK = 0x0203;

//			public const int WM_MOUSELEAVE = 0x02A3;


//			public const int WM_PAINT = 0x000F;
//			public const int WM_ERASEBKGND = 0x0014;

//			public const int WM_PRINT = 0x0317;

//			//const int EN_HSCROLL       =   0x0601;
//			//const int EN_VSCROLL       =   0x0602;

//			public const int WM_HSCROLL = 0x0114;
//			public const int WM_VSCROLL = 0x0115;


//			public const int EM_GETSEL = 0x00B0;
//			public const int EM_LINEINDEX = 0x00BB;
//			public const int EM_LINEFROMCHAR = 0x00C9;

//			public const int EM_POSFROMCHAR = 0x00D6;


//			private const int WM_PRINTCLIENT = 0x0318;

//			private const long PRF_CHECKVISIBLE = 0x00000001L;
//			private const long PRF_NONCLIENT = 0x00000002L;
//			private const long PRF_CLIENT = 0x00000004L;
//			private const long PRF_ERASEBKGND = 0x00000008L;
//			private const long PRF_CHILDREN = 0x00000010L;
//			private const long PRF_OWNED = 0x00000020L;


//			[DllImport("USER32.DLL", EntryPoint = "PostMessage")]
//			public static extern bool PostMessage(IntPtr hwnd, uint msg,
//				IntPtr wParam, IntPtr lParam);

//			/*
//				BOOL PostMessage(          HWND hWnd,
//					UINT Msg,
//					WPARAM wParam,
//					LPARAM lParam
//					);
//			*/

//			// Put this declaration in your class   //IntPtr
//			[DllImport("USER32.DLL", EntryPoint = "SendMessage")]
//			public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam,
//				IntPtr lParam);


//			[DllImport("USER32.DLL", EntryPoint = "GetCaretBlinkTime")]
//			public static extern uint GetCaretBlinkTime();

//			/*  Will clean this up later doing something like this
//			enum  CaptureOptions : long
//			{
//				PRF_CHECKVISIBLE= 0x00000001L,
//				PRF_NONCLIENT	= 0x00000002L,
//				PRF_CLIENT		= 0x00000004L,
//				PRF_ERASEBKGND	= 0x00000008L,
//				PRF_CHILDREN	= 0x00000010L,
//				PRF_OWNED		= 0x00000020L
//			}
//			*/


//			public static bool CaptureWindow(Control control,
//				ref Bitmap bitmap)
//			{
//				//This function captures the contents of a window or control

//				var g2 = Graphics.FromImage(bitmap);

//				//PRF_CHILDREN // PRF_NONCLIENT
//				var meint = (int)(PRF_CLIENT | PRF_ERASEBKGND); //| PRF_OWNED ); //  );
//				var meptr = new IntPtr(meint);

//				var hdc = g2.GetHdc();
//				SendMessage(control.Handle, WM_PRINT, hdc, meptr);

//				g2.ReleaseHdc(hdc);
//				g2.Dispose();

//				return true;
//			}
//		}

//		private sealed class UPictureBox : PictureBox
//		{
//			public UPictureBox()
//			{
//				SetStyle(ControlStyles.Selectable, false);
//				SetStyle(ControlStyles.UserPaint, true);
//				SetStyle(ControlStyles.AllPaintingInWmPaint, true);
//				SetStyle(ControlStyles.DoubleBuffer, true);

//				Cursor = null;
//				Enabled = true;
//				SizeMode = PictureBoxSizeMode.Normal;

//			}

//			//uPictureBox
//			protected override void WndProc(ref Message m)
//			{
//				if (m.Msg == Native.WM_LBUTTONDOWN
//					|| m.Msg == Native.WM_RBUTTONDOWN
//					|| m.Msg == Native.WM_LBUTTONDBLCLK
//					|| m.Msg == Native.WM_MOUSELEAVE
//					|| m.Msg == Native.WM_MOUSEMOVE)
//					//Send the above messages back to the parent control
//					Native.PostMessage(Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);

//				else if (m.Msg == Native.WM_LBUTTONUP)
//					//??  for selects and such
//					Parent.Invalidate();


//				base.WndProc(ref m);
//			}
//		}

//		private readonly UPictureBox uPictureBox;
//		private bool myUpToDate;
//		private bool myCaretUpToDate;
//		private Bitmap myBitmap;
//		private Bitmap myAlphaBitmap;

//		private int myFontHeight = 10;

//		private Timer myTimer1;

//		private bool myCaretState = true;

//		private bool myPaintedFirstTime;

//		private Color myBackColor = Color.White;
//		private int myBackAlpha = 10;

//		/// <summary> 
//		/// Required designer variable.
//		/// </summary>
//		private Container components;

//		[Category("Appearance")]
//		[Description("The alpha value used to blend the control's background. Valid values are 0 through 255.")]
//		[Browsable(true)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
//		public int BackAlpha
//		{
//			get => myBackAlpha;
//			set
//			{
//				var v = value;

//				if (v > 255)
//					v = 255;

//				myBackAlpha = v;
//				myUpToDate = false;
//				Invalidate();
//			}
//		}

//		public new BorderStyle BorderStyle
//		{
//			get => base.BorderStyle;
//			set
//			{
//				if (myPaintedFirstTime)
//					SetStyle(ControlStyles.UserPaint, false);

//				base.BorderStyle = value;

//				if (myPaintedFirstTime)
//					SetStyle(ControlStyles.UserPaint, true);

//				myBitmap = null;
//				myAlphaBitmap = null;
//				myUpToDate = false;
//				Invalidate();
//			}
//		}

//		public new Color BackColor
//		{
//			get => Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
//			set
//			{
//				myBackColor = value;
//				base.BackColor = value;
//				myUpToDate = false;
//			}
//		}

//		public override bool Multiline
//		{
//			get => base.Multiline;
//			set
//			{
//				if (myPaintedFirstTime)
//					SetStyle(ControlStyles.UserPaint, false);

//				base.Multiline = value;

//				if (myPaintedFirstTime)
//					SetStyle(ControlStyles.UserPaint, true);

//				myBitmap = null;
//				myAlphaBitmap = null;
//				myUpToDate = false;
//				Invalidate();
//			}
//		}

//		private void InitializeComponent()
//		{
//			components = new Container();
//		}

//		public AlphaBlendTextBox()
//		{
//			// This call is required by the Windows.Forms Form Designer.
//			InitializeComponent();
//			// TODO: Add any initialization after the InitializeComponent call
//			BackColor = myBackColor;

//			SetStyle(ControlStyles.UserPaint, false);
//			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
//			//SetStyle(ControlStyles.DoubleBuffer, true);

//			uPictureBox = new UPictureBox();
//			Controls.Add(uPictureBox);
//			uPictureBox.Dock = DockStyle.Fill;
//		}

//		protected override void OnResize(EventArgs e)
//		{

//			base.OnResize(e);
//			myBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height); //(this.Width,this.Height);
//			myAlphaBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height); //(this.Width,this.Height);
//			myUpToDate = false;
//			Invalidate();
//		}

//		//Some of these should be moved to the WndProc later

//		protected override void OnKeyDown(KeyEventArgs e)
//		{
//			base.OnKeyDown(e);
//			myUpToDate = false;
//			Invalidate();
//		}

//		protected override void OnKeyUp(KeyEventArgs e)
//		{
//			base.OnKeyUp(e);
//			myUpToDate = false;
//			Invalidate();

//		}

//		protected override void OnKeyPress(KeyPressEventArgs e)
//		{
//			base.OnKeyPress(e);
//			myUpToDate = false;
//			Invalidate();
//		}

//		protected override void OnMouseUp(MouseEventArgs e)
//		{
//			base.OnMouseUp(e);
//			Invalidate();
//		}

//		protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
//		{
//			base.OnGiveFeedback(gfbevent);
//			myUpToDate = false;
//			Invalidate();
//		}


//		protected override void OnMouseLeave(EventArgs e)
//		{
//			//found this code to find the current cursor location
//			//at http://www.syncfusion.com/FAQ/WinForms/FAQ_c50c.asp#q597q

//			var ptCursor = Cursor.Position;

//			var f = FindForm();
//			ptCursor = f.PointToClient(ptCursor);
//			if (!Bounds.Contains(ptCursor))
//				base.OnMouseLeave(e);
//		}


//		protected override void OnChangeUICues(UICuesEventArgs e)
//		{
//			base.OnChangeUICues(e);
//			myUpToDate = false;
//			Invalidate();
//		}

//		protected override void OnGotFocus(EventArgs e)
//		{
//			base.OnGotFocus(e);
//			myCaretUpToDate = false;
//			myUpToDate = false;
//			Invalidate();


//			myTimer1 = new Timer(components);
//			myTimer1.Interval = (int)Native.GetCaretBlinkTime(); //  usually around 500;

//			myTimer1.Tick += myTimer1_Tick;
//			myTimer1.Enabled = true;

//		}

//		protected override void OnLostFocus(EventArgs e)
//		{
//			base.OnLostFocus(e);
//			myCaretUpToDate = false;
//			myUpToDate = false;
//			Invalidate();

//			myTimer1.Dispose();
//		}

//		protected override void OnFontChanged(EventArgs e)
//		{
//			if (myPaintedFirstTime)
//				SetStyle(ControlStyles.UserPaint, false);

//			base.OnFontChanged(e);

//			if (myPaintedFirstTime)
//				SetStyle(ControlStyles.UserPaint, true);

//			myFontHeight = GetFontHeight();

//			myUpToDate = false;
//			Invalidate();
//		}

//		protected override void OnTextChanged(EventArgs e)
//		{
//			base.OnTextChanged(e);
//			myUpToDate = false;
//			Invalidate();
//		}

//		protected override void WndProc(ref Message m)
//		{
//			try
//			{
//				base.WndProc(ref m);
//			}
//			catch (Exception)
//			{
//				// TODO: разобраться!
//				return;
//			}

//			// need to rewrite as a big switch

//			if (m.Msg == Native.WM_PAINT)
//			{
//				myPaintedFirstTime = true;

//				if (!myUpToDate || !myCaretUpToDate)
//					GetBitmaps();
//				myUpToDate = true;
//				myCaretUpToDate = true;

//				if (uPictureBox.Image != null) uPictureBox.Image.Dispose();
//				uPictureBox.Image = (Image)myAlphaBitmap.Clone();

//			}

//			else if (m.Msg == Native.WM_HSCROLL || m.Msg == Native.WM_VSCROLL)
//			{
//				myUpToDate = false;
//				Invalidate();
//			}

//			else if (m.Msg == Native.WM_LBUTTONDOWN
//					 || m.Msg == Native.WM_RBUTTONDOWN
//					 || m.Msg == Native.WM_LBUTTONDBLCLK
//			//  || m.Msg == win32.WM_MOUSELEAVE  ///****
//			)
//			{
//				myUpToDate = false;
//				Invalidate();
//			}

//			else if (m.Msg == Native.WM_MOUSEMOVE)
//			{
//				if (m.WParam.ToInt32() != 0) //shift key or other buttons
//				{
//					myUpToDate = false;
//					Invalidate();
//				}
//			}

//			//System.Diagnostics.Debug.WriteLine("Pro: " + m.Msg.ToString("X"));

//		}

//		/// <summary> 
//		/// Clean up any resources being used.
//		/// </summary>
//		protected override void Dispose(bool disposing)
//		{
//			if (disposing)
//				//this.BackColor = Color.Pink;
//				if (components != null)
//					components.Dispose();
//			base.Dispose(disposing);
//		}

//		private int GetFontHeight()
//		{
//			var g = CreateGraphics();
//			var sfFont = g.MeasureString("X", Font);
//			g.Dispose();
//			return (int)sfFont.Height;
//		}

//		private void GetBitmaps()
//		{
//			if (myBitmap == null
//				|| myAlphaBitmap == null
//				|| myBitmap.Width != Width
//				|| myBitmap.Height != Height
//				|| myAlphaBitmap.Width != Width
//				|| myAlphaBitmap.Height != Height)
//			{
//				myBitmap = null;
//				myAlphaBitmap = null;
//			}

//			if (myBitmap == null)
//			{
//				myBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height); //(Width,Height);
//				myUpToDate = false;
//			}

//			if (!myUpToDate)
//			{
//				//Capture the TextBox control window

//				SetStyle(ControlStyles.UserPaint, false);

//				Native.CaptureWindow(this, ref myBitmap);

//				SetStyle(ControlStyles.UserPaint, true);
//				SetStyle(ControlStyles.SupportsTransparentBackColor, true);
//				BackColor = Color.FromArgb(myBackAlpha, myBackColor);

//			}

//			var r2 = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);
//			var tempImageAttr = new ImageAttributes();

//			//Found the color map code in the MS Help

//			var tempColorMap = new ColorMap[1];
//			tempColorMap[0] = new ColorMap();
//			tempColorMap[0].OldColor = Color.FromArgb(255, myBackColor);
//			tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha, myBackColor);

//			tempImageAttr.SetRemapTable(tempColorMap);

//			if (myAlphaBitmap != null)
//				myAlphaBitmap.Dispose();

//			myAlphaBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height); //(Width,Height);

//			var tempGraphics1 = Graphics.FromImage(myAlphaBitmap);

//			tempGraphics1.DrawImage(myBitmap, r2, 0, 0, ClientRectangle.Width, ClientRectangle.Height,
//				GraphicsUnit.Pixel, tempImageAttr);

//			tempGraphics1.Dispose();

//			if (Focused && SelectionLength == 0)
//			{
//				var tempGraphics2 = Graphics.FromImage(myAlphaBitmap);

//				if (myCaretState)
//				{
//					//Draw the caret
//					var caret = FindCaret();
//					var p = new Pen(ForeColor, 3);
//					tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + myFontHeight);
//					tempGraphics2.Dispose();
//				}
//			}
//		}

//		private Point FindCaret()
//		{
//			/*  Find the caret translated from code at 
//			 * http://www.vb-helper.com/howto_track_textbox_caret.html
//			 * 
//			 * and 
//			 * 
//			 * http://www.microbion.co.uk/developers/csharp/textpos2.htm
//			 * 
//			 * Changed to EM_POSFROMCHAR
//			 * 
//			 * This code still needs to be cleaned up and debugged
//			 * */

//			var pointCaret = new Point(0);
//			var iCharLoc = SelectionStart;
//			var piCharLoc = new IntPtr(iCharLoc);

//			var iPoint = Native.SendMessage(Handle, Native.EM_POSFROMCHAR, piCharLoc, IntPtr.Zero);
//			pointCaret = new Point(iPoint);

//			if (iCharLoc == 0)
//			{
//				pointCaret = new Point(0);
//			}
//			else if (iCharLoc >= Text.Length)
//			{
//				piCharLoc = new IntPtr(iCharLoc - 1);
//				iPoint = Native.SendMessage(Handle, Native.EM_POSFROMCHAR, piCharLoc, IntPtr.Zero);
//				pointCaret = new Point(iPoint);

//				var g = CreateGraphics();
//				var t1 = Text.Substring(Text.Length - 1, 1) + "X";
//				var sizeT1 = g.MeasureString(t1, Font);
//				var sizeX = g.MeasureString("X", Font);

//				g.Dispose();

//				var xOffset = (int)(sizeT1.Width - sizeX.Width);
//				pointCaret.X = pointCaret.X + xOffset;

//				if (iCharLoc == Text.Length)
//				{
//					var slast = Text.Substring(Text.Length - 1, 1);
//					if (slast == "\n")
//					{
//						pointCaret.X = 1;
//						pointCaret.Y = pointCaret.Y + myFontHeight;
//					}
//				}
//			}

//			return pointCaret;
//		}


//		private void myTimer1_Tick(object sender, EventArgs e)
//		{
//			//Timer used to turn caret on and off for focused control

//			myCaretState = !myCaretState;
//			myCaretUpToDate = false;
//			Invalidate();
//		}
//	}
//}
