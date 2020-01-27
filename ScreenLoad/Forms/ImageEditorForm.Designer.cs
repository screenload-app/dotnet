/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Drawing;
using System.Windows.Forms;
using ScreenLoad.Controls;

namespace ScreenLoad
{
    partial class ImageEditorForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditorForm));
            this.topToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dimensionsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new ScreenLoadPlugin.Controls.NonJumpingPanel();
            this.panel2 = new ScreenLoadPlugin.Controls.NonJumpingPanel();
            this.toolsToolStrip = new ScreenLoad.Controls.ToolStripEx();
            this.btnCursor = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRect = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnEllipse = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnLine = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnArrow = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnFreehand = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnText = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnSpeechBubble = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnStepLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHighlight = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnObfuscate = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSplitButton1 = new ScreenLoadPlugin.Controls.ScreenLoadToolStripDropDownButton();
            this.addBorderToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addDropshadowToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.tornEdgesToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.invertToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCrop = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.rotateCwToolstripButton = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.rotateCcwToolstripButton = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnResize = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.menuStrip1 = new ScreenLoad.Controls.MenuStripEx();
            this.fileStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.undoToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.redoToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.copyToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.pasteToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.autoCropToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.insert_window_toolstripmenuitem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.objectToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addRectangleToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addEllipseToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.drawLineToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.drawArrowToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.drawFreehandToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addTextBoxToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addSpeechBubbleToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.addCounterToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.removeObjectToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.arrangeToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.upToTopToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.upOneLevelToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.downOneLevelToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.downToBottomToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.saveElementsToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.loadElementsToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.pluginToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.helpToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.helpToolStripMenuItem1 = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.aboutToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.destinationsToolStrip = new ScreenLoad.Controls.ToolStripEx();
            this.btnSave = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnClipboard = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnPrint = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnCopy = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnPaste = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnUndo = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.btnRedo = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new ScreenLoadPlugin.Controls.ScreenLoadToolStripButton();
            this.closeToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.fileSavedStatusContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyPathMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.openDirectoryMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.propertiesToolStrip = new ScreenLoad.Controls.ToolStripEx();
            this.topToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.topToolStripContainer.ContentPanel.SuspendLayout();
            this.topToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.topToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.topToolStripContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolsToolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.destinationsToolStrip.SuspendLayout();
            this.fileSavedStatusContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // topToolStripContainer
            // 
            // 
            // topToolStripContainer.BottomToolStripPanel
            // 
            this.topToolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // topToolStripContainer.ContentPanel
            // 
            this.topToolStripContainer.ContentPanel.AutoScroll = true;
            this.topToolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.topToolStripContainer.ContentPanel.Size = new System.Drawing.Size(745, 398);
            this.topToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // topToolStripContainer.LeftToolStripPanel
            // 
            this.topToolStripContainer.LeftToolStripPanel.Controls.Add(this.toolsToolStrip);
            this.topToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.topToolStripContainer.Name = "topToolStripContainer";
            this.topToolStripContainer.Size = new System.Drawing.Size(785, 485);
            this.topToolStripContainer.TabIndex = 2;
            this.topToolStripContainer.Text = "toolStripContainer1";
            // 
            // topToolStripContainer.TopToolStripPanel
            // 
            this.topToolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.topToolStripContainer.TopToolStripPanel.Controls.Add(this.destinationsToolStrip);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dimensionsLabel,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(785, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dimensionsLabel
            // 
            this.dimensionsLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.dimensionsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.dimensionsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dimensionsLabel.Name = "dimensionsLabel";
            this.dimensionsLabel.Size = new System.Drawing.Size(53, 19);
            this.dimensionsLabel.Text = "123x321";
            // 
            // statusLabel
            // 
            this.statusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(4, 19);
            this.statusLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusLabelClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 398);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 340);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.propertiesToolStrip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 346);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(4, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 52);
            this.panel2.TabIndex = 3;
            // 
            // toolsToolStrip
            // 
            this.toolsToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolsToolStrip.ClickThrough = true;
            this.toolsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCursor,
            this.toolStripSeparator1,
            this.btnRect,
            this.btnEllipse,
            this.btnLine,
            this.btnArrow,
            this.btnFreehand,
            this.btnText,
            this.btnSpeechBubble,
            this.btnStepLabel,
            this.toolStripSeparator14,
            this.btnHighlight,
            this.btnObfuscate,
            this.toolStripSplitButton1,
            this.toolStripSeparator13,
            this.btnCrop,
            this.rotateCwToolstripButton,
            this.rotateCcwToolstripButton,
            this.btnResize});
            this.toolsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolsToolStrip.Name = "toolsToolStrip";
            this.toolsToolStrip.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.toolsToolStrip.Size = new System.Drawing.Size(40, 398);
            this.toolsToolStrip.Stretch = true;
            this.toolsToolStrip.TabIndex = 0;
            // 
            // btnCursor
            // 
            this.btnCursor.Checked = true;
            this.btnCursor.CheckOnClick = true;
            this.btnCursor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCursor.Image = ((System.Drawing.Image)(resources.GetObject("btnCursor.Image")));
            this.btnCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCursor.LanguageKey = "editor_cursortool";
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(35, 36);
            this.btnCursor.Text = "Selection Tool (ESC)";
            this.btnCursor.Click += new System.EventHandler(this.BtnCursorClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(35, 6);
            // 
            // btnRect
            // 
            this.btnRect.CheckOnClick = true;
            this.btnRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRect.Image = ((System.Drawing.Image)(resources.GetObject("btnRect.Image")));
            this.btnRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRect.LanguageKey = "editor_drawrectangle";
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(35, 36);
            this.btnRect.Text = "Draw rectangle (R)";
            this.btnRect.Click += new System.EventHandler(this.BtnRectClick);
            // 
            // btnEllipse
            // 
            this.btnEllipse.CheckOnClick = true;
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.LanguageKey = "editor_drawellipse";
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(35, 36);
            this.btnEllipse.Text = "Draw ellipse (E)";
            this.btnEllipse.Click += new System.EventHandler(this.BtnEllipseClick);
            // 
            // btnLine
            // 
            this.btnLine.CheckOnClick = true;
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.LanguageKey = "editor_drawline";
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(35, 36);
            this.btnLine.Text = "Draw line (L)";
            this.btnLine.Click += new System.EventHandler(this.BtnLineClick);
            // 
            // btnArrow
            // 
            this.btnArrow.CheckOnClick = true;
            this.btnArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnArrow.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow.Image")));
            this.btnArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArrow.LanguageKey = "editor_drawarrow";
            this.btnArrow.Name = "btnArrow";
            this.btnArrow.Size = new System.Drawing.Size(35, 36);
            this.btnArrow.Text = "Draw arrow (A)";
            this.btnArrow.Click += new System.EventHandler(this.BtnArrowClick);
            // 
            // btnFreehand
            // 
            this.btnFreehand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFreehand.Image = ((System.Drawing.Image)(resources.GetObject("btnFreehand.Image")));
            this.btnFreehand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFreehand.LanguageKey = "editor_drawfreehand";
            this.btnFreehand.Name = "btnFreehand";
            this.btnFreehand.Size = new System.Drawing.Size(35, 36);
            this.btnFreehand.Text = "Draw freehand (F)";
            this.btnFreehand.Click += new System.EventHandler(this.BtnFreehandClick);
            // 
            // btnText
            // 
            this.btnText.CheckOnClick = true;
            this.btnText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnText.Image = ((System.Drawing.Image)(resources.GetObject("btnText.Image")));
            this.btnText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnText.LanguageKey = "editor_drawtextbox";
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(35, 36);
            this.btnText.Text = "Add textbox (T)";
            this.btnText.Click += new System.EventHandler(this.BtnTextClick);
            // 
            // btnSpeechBubble
            // 
            this.btnSpeechBubble.CheckOnClick = true;
            this.btnSpeechBubble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpeechBubble.Image = ((System.Drawing.Image)(resources.GetObject("btnSpeechBubble.Image")));
            this.btnSpeechBubble.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpeechBubble.LanguageKey = "editor_speechbubble";
            this.btnSpeechBubble.Name = "btnSpeechBubble";
            this.btnSpeechBubble.Size = new System.Drawing.Size(35, 36);
            this.btnSpeechBubble.Text = "Add speechbubble (S)";
            this.btnSpeechBubble.Click += new System.EventHandler(this.BtnSpeechBubbleClick);
            // 
            // btnStepLabel
            // 
            this.btnStepLabel.CheckOnClick = true;
            this.btnStepLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStepLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnStepLabel.Image")));
            this.btnStepLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStepLabel.LanguageKey = "editor_counter";
            this.btnStepLabel.Name = "btnStepLabel";
            this.btnStepLabel.Size = new System.Drawing.Size(35, 36);
            this.btnStepLabel.Text = "Add counter (I)";
            this.btnStepLabel.Click += new System.EventHandler(this.BtnStepLabelClick);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(35, 6);
            // 
            // btnHighlight
            // 
            this.btnHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHighlight.Image = ((System.Drawing.Image)(resources.GetObject("btnHighlight.Image")));
            this.btnHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHighlight.LanguageKey = "editor_drawhighlighter";
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(35, 36);
            this.btnHighlight.Text = "Highlight (H)";
            this.btnHighlight.Click += new System.EventHandler(this.BtnHighlightClick);
            // 
            // btnObfuscate
            // 
            this.btnObfuscate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnObfuscate.Image = ((System.Drawing.Image)(resources.GetObject("btnObfuscate.Image")));
            this.btnObfuscate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnObfuscate.LanguageKey = "editor_obfuscate";
            this.btnObfuscate.Name = "btnObfuscate";
            this.btnObfuscate.Size = new System.Drawing.Size(36, 36);
            this.btnObfuscate.Text = "Obfuscate (O)";
            this.btnObfuscate.Click += new System.EventHandler(this.BtnObfuscateClick);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBorderToolStripMenuItem,
            this.addDropshadowToolStripMenuItem,
            this.tornEdgesToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.invertToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.LanguageKey = "editor_effects";
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.ShowDropDownArrow = false;
            this.toolStripSplitButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripSplitButton1.Text = "Effects";
            // 
            // addBorderToolStripMenuItem
            // 
            this.addBorderToolStripMenuItem.Icon = null;
            this.addBorderToolStripMenuItem.Image = null;
            this.addBorderToolStripMenuItem.LanguageKey = "editor_border";
            this.addBorderToolStripMenuItem.Name = "addBorderToolStripMenuItem";
            this.addBorderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addBorderToolStripMenuItem.Text = "Border";
            this.addBorderToolStripMenuItem.Click += new System.EventHandler(this.AddBorderToolStripMenuItemClick);
            // 
            // addDropshadowToolStripMenuItem
            // 
            this.addDropshadowToolStripMenuItem.Icon = null;
            this.addDropshadowToolStripMenuItem.Image = null;
            this.addDropshadowToolStripMenuItem.LanguageKey = "editor_image_shadow";
            this.addDropshadowToolStripMenuItem.Name = "addDropshadowToolStripMenuItem";
            this.addDropshadowToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addDropshadowToolStripMenuItem.Text = "Drop shadow";
            // 
            // tornEdgesToolStripMenuItem
            // 
            this.tornEdgesToolStripMenuItem.Icon = null;
            this.tornEdgesToolStripMenuItem.Image = null;
            this.tornEdgesToolStripMenuItem.LanguageKey = "editor_torn_edge";
            this.tornEdgesToolStripMenuItem.Name = "tornEdgesToolStripMenuItem";
            this.tornEdgesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.tornEdgesToolStripMenuItem.Text = "Torn edge";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Icon = null;
            this.grayscaleToolStripMenuItem.Image = null;
            this.grayscaleToolStripMenuItem.LanguageKey = "editor_grayscale";
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.GrayscaleToolStripMenuItemClick);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Icon = null;
            this.invertToolStripMenuItem.Image = null;
            this.invertToolStripMenuItem.LanguageKey = "editor_invert";
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.InvertToolStripMenuItemClick);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCrop
            // 
            this.btnCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCrop.Image = ((System.Drawing.Image)(resources.GetObject("btnCrop.Image")));
            this.btnCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrop.LanguageKey = "editor_crop";
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(36, 36);
            this.btnCrop.Text = "Crop (C)";
            this.btnCrop.Click += new System.EventHandler(this.BtnCropClick);
            // 
            // rotateCwToolstripButton
            // 
            this.rotateCwToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCwToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCwToolstripButton.Image")));
            this.rotateCwToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCwToolstripButton.LanguageKey = "editor_rotatecw";
            this.rotateCwToolstripButton.Name = "rotateCwToolstripButton";
            this.rotateCwToolstripButton.Size = new System.Drawing.Size(36, 36);
            this.rotateCwToolstripButton.Text = "Rotate clockwise (Control + .)";
            this.rotateCwToolstripButton.Click += new System.EventHandler(this.RotateCwToolstripButtonClick);
            // 
            // rotateCcwToolstripButton
            // 
            this.rotateCcwToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCcwToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCcwToolstripButton.Image")));
            this.rotateCcwToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCcwToolstripButton.LanguageKey = "editor_rotateccw";
            this.rotateCcwToolstripButton.Name = "rotateCcwToolstripButton";
            this.rotateCcwToolstripButton.Size = new System.Drawing.Size(36, 36);
            this.rotateCcwToolstripButton.Text = "Rotate counter clockwise (Control + ,)";
            this.rotateCcwToolstripButton.Click += new System.EventHandler(this.RotateCcwToolstripButtonClick);
            // 
            // btnResize
            // 
            this.btnResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResize.Image = ((System.Drawing.Image)(resources.GetObject("btnResize.Image")));
            this.btnResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResize.LanguageKey = "editor_resize";
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(36, 36);
            this.btnResize.Text = "Resize";
            this.btnResize.Click += new System.EventHandler(this.BtnResizeClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ClickThrough = true;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenuItem,
            this.editToolStripMenuItem,
            this.objectToolStripMenuItem,
            this.pluginToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // fileStripMenuItem
            // 
            this.fileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9});
            this.fileStripMenuItem.Icon = null;
            this.fileStripMenuItem.Image = null;
            this.fileStripMenuItem.LanguageKey = "editor_file";
            this.fileStripMenuItem.Name = "fileStripMenuItem";
            this.fileStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileStripMenuItem.Text = "File";
            this.fileStripMenuItem.DropDownOpening += new System.EventHandler(this.FileMenuDropDownOpening);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(177, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator15,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.duplicateToolStripMenuItem,
            this.toolStripSeparator12,
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator5,
            this.autoCropToolStripMenuItem,
            this.toolStripSeparator17,
            this.insert_window_toolstripmenuitem});
            this.editToolStripMenuItem.Icon = null;
            this.editToolStripMenuItem.Image = null;
            this.editToolStripMenuItem.LanguageKey = "editor_edit";
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItemClick);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("undoToolStripMenuItem.Icon")));
            this.undoToolStripMenuItem.Image = null;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("redoToolStripMenuItem.Icon")));
            this.redoToolStripMenuItem.Image = null;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItemClick);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(255, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("cutToolStripMenuItem.Icon")));
            this.cutToolStripMenuItem.Image = null;
            this.cutToolStripMenuItem.LanguageKey = "editor_cuttoclipboard";
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItemClick);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("copyToolStripMenuItem.Icon")));
            this.copyToolStripMenuItem.Image = null;
            this.copyToolStripMenuItem.LanguageKey = "editor_copytoclipboard";
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("pasteToolStripMenuItem.Icon")));
            this.pasteToolStripMenuItem.Image = null;
            this.pasteToolStripMenuItem.LanguageKey = "editor_pastefromclipboard";
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(255, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Enabled = false;
            this.duplicateToolStripMenuItem.Icon = null;
            this.duplicateToolStripMenuItem.Image = null;
            this.duplicateToolStripMenuItem.LanguageKey = "editor_duplicate";
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate selected element";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.DuplicateToolStripMenuItemClick);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(255, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("preferencesToolStripMenuItem.Icon")));
            this.preferencesToolStripMenuItem.Image = null;
            this.preferencesToolStripMenuItem.LanguageKey = "contextmenu_settings";
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.preferencesToolStripMenuItem.Text = "Settings";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(255, 6);
            // 
            // autoCropToolStripMenuItem
            // 
            this.autoCropToolStripMenuItem.Icon = null;
            this.autoCropToolStripMenuItem.Image = null;
            this.autoCropToolStripMenuItem.LanguageKey = "editor_autocrop";
            this.autoCropToolStripMenuItem.Name = "autoCropToolStripMenuItem";
            this.autoCropToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.autoCropToolStripMenuItem.Text = "Auto crop";
            this.autoCropToolStripMenuItem.Click += new System.EventHandler(this.AutoCropToolStripMenuItemClick);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(255, 6);
            // 
            // insert_window_toolstripmenuitem
            // 
            this.insert_window_toolstripmenuitem.Icon = null;
            this.insert_window_toolstripmenuitem.Image = null;
            this.insert_window_toolstripmenuitem.LanguageKey = "editor_insertwindow";
            this.insert_window_toolstripmenuitem.Name = "insert_window_toolstripmenuitem";
            this.insert_window_toolstripmenuitem.Size = new System.Drawing.Size(258, 22);
            this.insert_window_toolstripmenuitem.Text = "Insert window";
            this.insert_window_toolstripmenuitem.MouseEnter += new System.EventHandler(this.Insert_window_toolstripmenuitemMouseEnter);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRectangleToolStripMenuItem,
            this.addEllipseToolStripMenuItem,
            this.drawLineToolStripMenuItem,
            this.drawArrowToolStripMenuItem,
            this.drawFreehandToolStripMenuItem,
            this.addTextBoxToolStripMenuItem,
            this.addSpeechBubbleToolStripMenuItem,
            this.addCounterToolStripMenuItem,
            this.toolStripSeparator8,
            this.selectAllToolStripMenuItem,
            this.removeObjectToolStripMenuItem,
            this.toolStripSeparator7,
            this.arrangeToolStripMenuItem,
            this.saveElementsToolStripMenuItem,
            this.loadElementsToolStripMenuItem});
            this.objectToolStripMenuItem.Icon = null;
            this.objectToolStripMenuItem.Image = null;
            this.objectToolStripMenuItem.LanguageKey = "editor_object";
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.objectToolStripMenuItem.Text = "Object";
            // 
            // addRectangleToolStripMenuItem
            // 
            this.addRectangleToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addRectangleToolStripMenuItem.Icon")));
            this.addRectangleToolStripMenuItem.Image = null;
            this.addRectangleToolStripMenuItem.LanguageKey = "editor_drawrectangle";
            this.addRectangleToolStripMenuItem.Name = "addRectangleToolStripMenuItem";
            this.addRectangleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addRectangleToolStripMenuItem.Text = "Draw rectangle (R)";
            this.addRectangleToolStripMenuItem.Click += new System.EventHandler(this.AddRectangleToolStripMenuItemClick);
            // 
            // addEllipseToolStripMenuItem
            // 
            this.addEllipseToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addEllipseToolStripMenuItem.Icon")));
            this.addEllipseToolStripMenuItem.Image = null;
            this.addEllipseToolStripMenuItem.LanguageKey = "editor_drawellipse";
            this.addEllipseToolStripMenuItem.Name = "addEllipseToolStripMenuItem";
            this.addEllipseToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addEllipseToolStripMenuItem.Text = "Draw ellipse (E)";
            this.addEllipseToolStripMenuItem.Click += new System.EventHandler(this.AddEllipseToolStripMenuItemClick);
            // 
            // drawLineToolStripMenuItem
            // 
            this.drawLineToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawLineToolStripMenuItem.Icon")));
            this.drawLineToolStripMenuItem.Image = null;
            this.drawLineToolStripMenuItem.LanguageKey = "editor_drawline";
            this.drawLineToolStripMenuItem.Name = "drawLineToolStripMenuItem";
            this.drawLineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawLineToolStripMenuItem.Text = "Draw line (L)";
            this.drawLineToolStripMenuItem.Click += new System.EventHandler(this.DrawLineToolStripMenuItemClick);
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawArrowToolStripMenuItem.Icon")));
            this.drawArrowToolStripMenuItem.Image = null;
            this.drawArrowToolStripMenuItem.LanguageKey = "editor_drawarrow";
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow (A)";
            this.drawArrowToolStripMenuItem.Click += new System.EventHandler(this.DrawArrowToolStripMenuItemClick);
            // 
            // drawFreehandToolStripMenuItem
            // 
            this.drawFreehandToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawFreehandToolStripMenuItem.Icon")));
            this.drawFreehandToolStripMenuItem.Image = null;
            this.drawFreehandToolStripMenuItem.LanguageKey = "editor_drawfreehand";
            this.drawFreehandToolStripMenuItem.Name = "drawFreehandToolStripMenuItem";
            this.drawFreehandToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawFreehandToolStripMenuItem.Text = "Draw freehand (F)";
            this.drawFreehandToolStripMenuItem.Click += new System.EventHandler(this.DrawFreehandToolStripMenuItemClick);
            // 
            // addTextBoxToolStripMenuItem
            // 
            this.addTextBoxToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addTextBoxToolStripMenuItem.Icon")));
            this.addTextBoxToolStripMenuItem.Image = null;
            this.addTextBoxToolStripMenuItem.LanguageKey = "editor_drawtextbox";
            this.addTextBoxToolStripMenuItem.Name = "addTextBoxToolStripMenuItem";
            this.addTextBoxToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addTextBoxToolStripMenuItem.Text = "Add textbox (T)";
            this.addTextBoxToolStripMenuItem.Click += new System.EventHandler(this.AddTextBoxToolStripMenuItemClick);
            // 
            // addSpeechBubbleToolStripMenuItem
            // 
            this.addSpeechBubbleToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addSpeechBubbleToolStripMenuItem.Icon")));
            this.addSpeechBubbleToolStripMenuItem.Image = null;
            this.addSpeechBubbleToolStripMenuItem.LanguageKey = "editor_speechbubble";
            this.addSpeechBubbleToolStripMenuItem.Name = "addSpeechBubbleToolStripMenuItem";
            this.addSpeechBubbleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addSpeechBubbleToolStripMenuItem.Text = "Add speechbubble (S)";
            this.addSpeechBubbleToolStripMenuItem.Click += new System.EventHandler(this.AddSpeechBubbleToolStripMenuItemClick);
            // 
            // addCounterToolStripMenuItem
            // 
            this.addCounterToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addCounterToolStripMenuItem.Icon")));
            this.addCounterToolStripMenuItem.Image = null;
            this.addCounterToolStripMenuItem.LanguageKey = "editor_counter";
            this.addCounterToolStripMenuItem.Name = "addCounterToolStripMenuItem";
            this.addCounterToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addCounterToolStripMenuItem.Text = "Add counter (I)";
            this.addCounterToolStripMenuItem.Click += new System.EventHandler(this.AddCounterToolStripMenuItemClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(187, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Icon = null;
            this.selectAllToolStripMenuItem.Image = null;
            this.selectAllToolStripMenuItem.LanguageKey = "editor_selectall";
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
            // 
            // removeObjectToolStripMenuItem
            // 
            this.removeObjectToolStripMenuItem.Enabled = false;
            this.removeObjectToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("removeObjectToolStripMenuItem.Icon")));
            this.removeObjectToolStripMenuItem.Image = null;
            this.removeObjectToolStripMenuItem.LanguageKey = "editor_deleteelement";
            this.removeObjectToolStripMenuItem.Name = "removeObjectToolStripMenuItem";
            this.removeObjectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeObjectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeObjectToolStripMenuItem.Text = "Delete";
            this.removeObjectToolStripMenuItem.Click += new System.EventHandler(this.RemoveObjectToolStripMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(187, 6);
            // 
            // arrangeToolStripMenuItem
            // 
            this.arrangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToTopToolStripMenuItem,
            this.upOneLevelToolStripMenuItem,
            this.downOneLevelToolStripMenuItem,
            this.downToBottomToolStripMenuItem});
            this.arrangeToolStripMenuItem.Enabled = false;
            this.arrangeToolStripMenuItem.Icon = null;
            this.arrangeToolStripMenuItem.Image = null;
            this.arrangeToolStripMenuItem.LanguageKey = "editor_arrange";
            this.arrangeToolStripMenuItem.Name = "arrangeToolStripMenuItem";
            this.arrangeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.arrangeToolStripMenuItem.Text = "Arrange";
            // 
            // upToTopToolStripMenuItem
            // 
            this.upToTopToolStripMenuItem.Enabled = false;
            this.upToTopToolStripMenuItem.Icon = null;
            this.upToTopToolStripMenuItem.Image = null;
            this.upToTopToolStripMenuItem.LanguageKey = "editor_uptotop";
            this.upToTopToolStripMenuItem.Name = "upToTopToolStripMenuItem";
            this.upToTopToolStripMenuItem.ShortcutKeyDisplayString = "Home";
            this.upToTopToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.upToTopToolStripMenuItem.Text = "Up to top";
            this.upToTopToolStripMenuItem.Click += new System.EventHandler(this.UpToTopToolStripMenuItemClick);
            // 
            // upOneLevelToolStripMenuItem
            // 
            this.upOneLevelToolStripMenuItem.Enabled = false;
            this.upOneLevelToolStripMenuItem.Icon = null;
            this.upOneLevelToolStripMenuItem.Image = null;
            this.upOneLevelToolStripMenuItem.LanguageKey = "editor_uponelevel";
            this.upOneLevelToolStripMenuItem.Name = "upOneLevelToolStripMenuItem";
            this.upOneLevelToolStripMenuItem.ShortcutKeyDisplayString = "PgUp";
            this.upOneLevelToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.upOneLevelToolStripMenuItem.Text = "Up one level";
            this.upOneLevelToolStripMenuItem.Click += new System.EventHandler(this.UpOneLevelToolStripMenuItemClick);
            // 
            // downOneLevelToolStripMenuItem
            // 
            this.downOneLevelToolStripMenuItem.Enabled = false;
            this.downOneLevelToolStripMenuItem.Icon = null;
            this.downOneLevelToolStripMenuItem.Image = null;
            this.downOneLevelToolStripMenuItem.LanguageKey = "editor_downonelevel";
            this.downOneLevelToolStripMenuItem.Name = "downOneLevelToolStripMenuItem";
            this.downOneLevelToolStripMenuItem.ShortcutKeyDisplayString = "PgDn";
            this.downOneLevelToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.downOneLevelToolStripMenuItem.Text = "Down one level";
            this.downOneLevelToolStripMenuItem.Click += new System.EventHandler(this.DownOneLevelToolStripMenuItemClick);
            // 
            // downToBottomToolStripMenuItem
            // 
            this.downToBottomToolStripMenuItem.Enabled = false;
            this.downToBottomToolStripMenuItem.Icon = null;
            this.downToBottomToolStripMenuItem.Image = null;
            this.downToBottomToolStripMenuItem.LanguageKey = "editor_downtobottom";
            this.downToBottomToolStripMenuItem.Name = "downToBottomToolStripMenuItem";
            this.downToBottomToolStripMenuItem.ShortcutKeyDisplayString = "End";
            this.downToBottomToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.downToBottomToolStripMenuItem.Text = "Down to bottom";
            this.downToBottomToolStripMenuItem.Click += new System.EventHandler(this.DownToBottomToolStripMenuItemClick);
            // 
            // saveElementsToolStripMenuItem
            // 
            this.saveElementsToolStripMenuItem.Icon = null;
            this.saveElementsToolStripMenuItem.Image = null;
            this.saveElementsToolStripMenuItem.LanguageKey = "editor_save_objects";
            this.saveElementsToolStripMenuItem.Name = "saveElementsToolStripMenuItem";
            this.saveElementsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveElementsToolStripMenuItem.Text = "Save objects to file";
            this.saveElementsToolStripMenuItem.Click += new System.EventHandler(this.SaveElementsToolStripMenuItemClick);
            // 
            // loadElementsToolStripMenuItem
            // 
            this.loadElementsToolStripMenuItem.Icon = null;
            this.loadElementsToolStripMenuItem.Image = null;
            this.loadElementsToolStripMenuItem.LanguageKey = "editor_load_objects";
            this.loadElementsToolStripMenuItem.Name = "loadElementsToolStripMenuItem";
            this.loadElementsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadElementsToolStripMenuItem.Text = "Load objects from file";
            this.loadElementsToolStripMenuItem.Click += new System.EventHandler(this.LoadElementsToolStripMenuItemClick);
            // 
            // pluginToolStripMenuItem
            // 
            this.pluginToolStripMenuItem.Icon = null;
            this.pluginToolStripMenuItem.Image = null;
            this.pluginToolStripMenuItem.LanguageKey = "settings_plugins";
            this.pluginToolStripMenuItem.Name = "pluginToolStripMenuItem";
            this.pluginToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginToolStripMenuItem.Text = "Plugins";
            this.pluginToolStripMenuItem.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Icon = null;
            this.helpToolStripMenuItem.Image = null;
            this.helpToolStripMenuItem.LanguageKey = "contextmenu_help";
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Icon = ((System.Drawing.Icon)(resources.GetObject("helpToolStripMenuItem1.Icon")));
            this.helpToolStripMenuItem1.Image = null;
            this.helpToolStripMenuItem1.LanguageKey = "contextmenu_help";
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Icon = null;
            this.aboutToolStripMenuItem.Image = null;
            this.aboutToolStripMenuItem.LanguageKey = "contextmenu_about";
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About ScreenLoad";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // destinationsToolStrip
            // 
            this.destinationsToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.destinationsToolStrip.ClickThrough = true;
            this.destinationsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.destinationsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.destinationsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.destinationsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClipboard,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator6,
            this.btnSettings,
            this.toolStripSeparator11,
            this.toolStripSeparator16,
            this.btnHelp});
            this.destinationsToolStrip.Location = new System.Drawing.Point(0, 24);
            this.destinationsToolStrip.Name = "destinationsToolStrip";
            this.destinationsToolStrip.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.destinationsToolStrip.Size = new System.Drawing.Size(785, 39);
            this.destinationsToolStrip.Stretch = true;
            this.destinationsToolStrip.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.LanguageKey = "editor_save";
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnClipboard
            // 
            this.btnClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnClipboard.Image")));
            this.btnClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClipboard.LanguageKey = "editor_copyimagetoclipboard";
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(36, 36);
            this.btnClipboard.Text = "Copy image to clipboard";
            this.btnClipboard.Click += new System.EventHandler(this.BtnClipboardClick);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.LanguageKey = "editor_print";
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(36, 36);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.LanguageKey = "editor_deleteelement";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 36);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Enabled = false;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.LanguageKey = "editor_cuttoclipboard";
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(36, 36);
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.BtnCutClick);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.LanguageKey = "editor_copytoclipboard";
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(36, 36);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Enabled = false;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.LanguageKey = "editor_pastefromclipboard";
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(36, 36);
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.BtnPasteClick);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(36, 36);
            this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Enabled = false;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(36, 36);
            this.btnRedo.Click += new System.EventHandler(this.BtnRedoClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.LanguageKey = "contextmenu_settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(36, 36);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 39);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.LanguageKey = "contextmenu_help";
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(36, 36);
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.BtnHelpClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("closeToolStripMenuItem.Icon")));
            this.closeToolStripMenuItem.Image = null;
            this.closeToolStripMenuItem.LanguageKey = "editor_close";
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // fileSavedStatusContextMenu
            // 
            this.fileSavedStatusContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyPathMenuItem,
            this.openDirectoryMenuItem});
            this.fileSavedStatusContextMenu.Name = "contextMenuStrip1";
            this.fileSavedStatusContextMenu.Size = new System.Drawing.Size(265, 48);
            // 
            // copyPathMenuItem
            // 
            this.copyPathMenuItem.Icon = null;
            this.copyPathMenuItem.Image = null;
            this.copyPathMenuItem.LanguageKey = "editor_copypathtoclipboard";
            this.copyPathMenuItem.Name = "copyPathMenuItem";
            this.copyPathMenuItem.Size = new System.Drawing.Size(264, 22);
            this.copyPathMenuItem.Text = "Copy path to clipboard";
            this.copyPathMenuItem.Click += new System.EventHandler(this.CopyPathMenuItemClick);
            // 
            // openDirectoryMenuItem
            // 
            this.openDirectoryMenuItem.Icon = null;
            this.openDirectoryMenuItem.Image = null;
            this.openDirectoryMenuItem.LanguageKey = "editor_opendirinexplorer";
            this.openDirectoryMenuItem.Name = "openDirectoryMenuItem";
            this.openDirectoryMenuItem.Size = new System.Drawing.Size(264, 22);
            this.openDirectoryMenuItem.Text = "Open directory in Windows Explorer";
            this.openDirectoryMenuItem.Click += new System.EventHandler(this.OpenDirectoryMenuItemClick);
            // 
            // propertiesToolStrip
            // 
            this.propertiesToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.propertiesToolStrip.ClickThrough = true;
            this.propertiesToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.propertiesToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.propertiesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.propertiesToolStrip.Name = "propertiesToolStrip";
            this.propertiesToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.propertiesToolStrip.Size = new System.Drawing.Size(735, 48);
            this.propertiesToolStrip.Stretch = true;
            this.propertiesToolStrip.TabIndex = 2;
            // 
            // ImageEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(785, 485);
            this.Controls.Add(this.topToolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LanguageKey = "editor_title";
            this.Name = "ImageEditorForm";
            this.Text = "ScreenLoad image editor";
            this.Activated += new System.EventHandler(this.ImageEditorFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageEditorFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageEditorFormKeyDown);
            this.Resize += new System.EventHandler(this.ImageEditorFormResize);
            this.topToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.topToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.topToolStripContainer.ContentPanel.ResumeLayout(false);
            this.topToolStripContainer.LeftToolStripPanel.ResumeLayout(false);
            this.topToolStripContainer.LeftToolStripPanel.PerformLayout();
            this.topToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.topToolStripContainer.TopToolStripPanel.PerformLayout();
            this.topToolStripContainer.ResumeLayout(false);
            this.topToolStripContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolsToolStrip.ResumeLayout(false);
            this.toolsToolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.destinationsToolStrip.ResumeLayout(false);
            this.destinationsToolStrip.PerformLayout();
            this.fileSavedStatusContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem invertToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnResize;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem grayscaleToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton rotateCcwToolstripButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton rotateCwToolstripButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addBorderToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem tornEdgesToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addDropshadowToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel dimensionsLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem insert_window_toolstripmenuitem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem selectAllToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnHighlight;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem loadElementsToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem saveElementsToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem pluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnFreehand;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnObfuscate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnCrop;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem openDirectoryMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem copyPathMenuItem;
        private System.Windows.Forms.ContextMenuStrip fileSavedStatusContextMenu;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem downToBottomToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem upToTopToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem downOneLevelToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem upOneLevelToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem arrangeToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnCursor;
        private ScreenLoad.Controls.ToolStripEx toolsToolStrip;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnArrow;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem drawArrowToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem drawFreehandToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnText;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnSpeechBubble;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnStepLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem drawLineToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnLine;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnSettings;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem aboutToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem helpToolStripMenuItem1;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem helpToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnPrint;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem fileStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem removeObjectToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addTextBoxToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addSpeechBubbleToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addCounterToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addEllipseToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem addRectangleToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem objectToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem undoToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem redoToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem pasteToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem copyToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem cutToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem editToolStripMenuItem;
        private ScreenLoad.Controls.MenuStripEx menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnCut;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnCopy;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnPaste;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnUndo;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnClipboard;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnEllipse;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnSave;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnRect;
        private System.Windows.Forms.ToolStripContainer topToolStripContainer;
        private ScreenLoad.Controls.ToolStripEx destinationsToolStrip;
        private ScreenLoadPlugin.Controls.NonJumpingPanel panel1;
        private ScreenLoadPlugin.Controls.NonJumpingPanel panel2;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem autoCropToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private ToolStripEx propertiesToolStrip;
    }
}