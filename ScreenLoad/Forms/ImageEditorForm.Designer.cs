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
            this.propertiesToolStrip = new ScreenLoad.Controls.ToolStripEx();
            this.obfuscateModeButton = new ScreenLoad.Controls.BindableToolStripDropDownButton();
            this.pixelizeToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.blurToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.highlightModeButton = new ScreenLoad.Controls.BindableToolStripDropDownButton();
            this.textHighlightMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.areaHighlightMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.grayscaleHighlightMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.magnifyMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.btnFillColor = new ScreenLoad.Controls.ToolStripColorButton();
            this.btnLineColor = new ScreenLoad.Controls.ToolStripColorButton();
            this.lineThicknessLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.lineThicknessUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.fontFamilyComboBox = new ScreenLoad.Controls.FontFamilyComboBox();
            this.fontSizeLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.fontSizeUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.fontBoldButton = new ScreenLoad.Controls.BindableToolStripButton();
            this.fontItalicButton = new ScreenLoad.Controls.BindableToolStripButton();
            this.textHorizontalAlignmentButton = new ScreenLoad.Controls.BindableToolStripDropDownButton();
            this.alignLeftToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.alignCenterToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.alignRightToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.textVerticalAlignmentButton = new ScreenLoad.Controls.BindableToolStripDropDownButton();
            this.alignTopToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.alignMiddleToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.alignBottomToolStripMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.blurRadiusLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.blurRadiusUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.brightnessLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.brightnessUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.previewQualityLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.previewQualityUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.magnificationFactorLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.magnificationFactorUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.pixelSizeLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.pixelSizeUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.arrowHeadsLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.arrowHeadsDropDownButton = new ScreenLoad.Controls.BindableToolStripDropDownButton();
            this.arrowHeadStartMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.arrowHeadEndMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.arrowHeadBothMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.arrowHeadNoneMenuItem = new ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem();
            this.shadowButton = new ScreenLoad.Controls.BindableToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfirm = new ScreenLoad.Controls.BindableToolStripButton();
            this.btnCancel = new ScreenLoad.Controls.BindableToolStripButton();
            this.counterLabel = new ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel();
            this.counterUpDown = new ScreenLoad.Controls.ToolStripNumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dimensionsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new ScreenLoadPlugin.Controls.NonJumpingPanel();
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
            this.topToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.topToolStripContainer.ContentPanel.SuspendLayout();
            this.topToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.topToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.topToolStripContainer.SuspendLayout();
            this.propertiesToolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.topToolStripContainer.BottomToolStripPanel.Controls.Add(this.propertiesToolStrip);
            this.topToolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // topToolStripContainer.ContentPanel
            // 
            this.topToolStripContainer.ContentPanel.AutoScroll = true;
            this.topToolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.topToolStripContainer.ContentPanel.Size = new System.Drawing.Size(745, 359);
            this.topToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // topToolStripContainer.LeftToolStripPanel
            // 
            this.topToolStripContainer.LeftToolStripPanel.Controls.Add(this.toolsToolStrip);
            this.topToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.topToolStripContainer.Name = "topToolStripContainer";
            this.topToolStripContainer.RightToolStripPanelVisible = false;
            this.topToolStripContainer.Size = new System.Drawing.Size(785, 485);
            this.topToolStripContainer.TabIndex = 2;
            this.topToolStripContainer.Text = "toolStripContainer1";
            // 
            // topToolStripContainer.TopToolStripPanel
            // 
            this.topToolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.topToolStripContainer.TopToolStripPanel.Controls.Add(this.destinationsToolStrip);
            // 
            // propertiesToolStrip
            // 
            this.propertiesToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.propertiesToolStrip.ClickThrough = true;
            this.propertiesToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.propertiesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.propertiesToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.propertiesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obfuscateModeButton,
            this.highlightModeButton,
            this.btnFillColor,
            this.btnLineColor,
            this.lineThicknessLabel,
            this.lineThicknessUpDown,
            this.fontFamilyComboBox,
            this.fontSizeLabel,
            this.fontSizeUpDown,
            this.fontBoldButton,
            this.fontItalicButton,
            this.textHorizontalAlignmentButton,
            this.textVerticalAlignmentButton,
            this.blurRadiusLabel,
            this.blurRadiusUpDown,
            this.brightnessLabel,
            this.brightnessUpDown,
            this.previewQualityLabel,
            this.previewQualityUpDown,
            this.magnificationFactorLabel,
            this.magnificationFactorUpDown,
            this.pixelSizeLabel,
            this.pixelSizeUpDown,
            this.arrowHeadsLabel,
            this.arrowHeadsDropDownButton,
            this.shadowButton,
            this.toolStripSeparator,
            this.toolStripSeparator10,
            this.btnConfirm,
            this.btnCancel,
            this.counterLabel,
            this.counterUpDown});
            this.propertiesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.propertiesToolStrip.MinimumSize = new System.Drawing.Size(150, 32);
            this.propertiesToolStrip.Name = "propertiesToolStrip";
            this.propertiesToolStrip.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.propertiesToolStrip.Size = new System.Drawing.Size(785, 39);
            this.propertiesToolStrip.Stretch = true;
            this.propertiesToolStrip.TabIndex = 2;
            // 
            // obfuscateModeButton
            // 
            this.obfuscateModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.obfuscateModeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixelizeToolStripMenuItem,
            this.blurToolStripMenuItem});
            this.obfuscateModeButton.Image = ((System.Drawing.Image)(resources.GetObject("obfuscateModeButton.Image")));
            this.obfuscateModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.obfuscateModeButton.LanguageKey = "editor_obfuscate_mode";
            this.obfuscateModeButton.Name = "obfuscateModeButton";
            this.obfuscateModeButton.SelectedTag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.BLUR;
            this.obfuscateModeButton.Size = new System.Drawing.Size(45, 36);
            this.obfuscateModeButton.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.BLUR;
            this.obfuscateModeButton.Text = "Obfuscation mode";
            // 
            // pixelizeToolStripMenuItem
            // 
            this.pixelizeToolStripMenuItem.Icon = null;
            this.pixelizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pixelizeToolStripMenuItem.Image")));
            this.pixelizeToolStripMenuItem.LanguageKey = "editor_obfuscate_pixelize";
            this.pixelizeToolStripMenuItem.Name = "pixelizeToolStripMenuItem";
            this.pixelizeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.pixelizeToolStripMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.PIXELIZE;
            this.pixelizeToolStripMenuItem.Text = "Pixelize";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Icon = null;
            this.blurToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("blurToolStripMenuItem.Image")));
            this.blurToolStripMenuItem.LanguageKey = "editor_obfuscate_blur";
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.blurToolStripMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.BLUR;
            this.blurToolStripMenuItem.Text = "Blur";
            // 
            // highlightModeButton
            // 
            this.highlightModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.highlightModeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textHighlightMenuItem,
            this.areaHighlightMenuItem,
            this.grayscaleHighlightMenuItem,
            this.magnifyMenuItem});
            this.highlightModeButton.Image = ((System.Drawing.Image)(resources.GetObject("highlightModeButton.Image")));
            this.highlightModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.highlightModeButton.LanguageKey = "editor_highlight_mode";
            this.highlightModeButton.Name = "highlightModeButton";
            this.highlightModeButton.SelectedTag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.TEXT_HIGHTLIGHT;
            this.highlightModeButton.Size = new System.Drawing.Size(45, 36);
            this.highlightModeButton.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.TEXT_HIGHTLIGHT;
            this.highlightModeButton.Text = "Highlight mode";
            // 
            // textHighlightMenuItem
            // 
            this.textHighlightMenuItem.Icon = null;
            this.textHighlightMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("textHighlightMenuItem.Image")));
            this.textHighlightMenuItem.LanguageKey = "editor_highlight_text";
            this.textHighlightMenuItem.Name = "textHighlightMenuItem";
            this.textHighlightMenuItem.Size = new System.Drawing.Size(149, 22);
            this.textHighlightMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.TEXT_HIGHTLIGHT;
            this.textHighlightMenuItem.Text = "Highlight text";
            // 
            // areaHighlightMenuItem
            // 
            this.areaHighlightMenuItem.Icon = null;
            this.areaHighlightMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("areaHighlightMenuItem.Image")));
            this.areaHighlightMenuItem.LanguageKey = "editor_highlight_area";
            this.areaHighlightMenuItem.Name = "areaHighlightMenuItem";
            this.areaHighlightMenuItem.Size = new System.Drawing.Size(149, 22);
            this.areaHighlightMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.AREA_HIGHLIGHT;
            this.areaHighlightMenuItem.Text = "Highlight area";
            // 
            // grayscaleHighlightMenuItem
            // 
            this.grayscaleHighlightMenuItem.Icon = null;
            this.grayscaleHighlightMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("grayscaleHighlightMenuItem.Image")));
            this.grayscaleHighlightMenuItem.LanguageKey = "editor_highlight_grayscale";
            this.grayscaleHighlightMenuItem.Name = "grayscaleHighlightMenuItem";
            this.grayscaleHighlightMenuItem.Size = new System.Drawing.Size(149, 22);
            this.grayscaleHighlightMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.GRAYSCALE;
            this.grayscaleHighlightMenuItem.Text = "Grayscale";
            // 
            // magnifyMenuItem
            // 
            this.magnifyMenuItem.Icon = null;
            this.magnifyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("magnifyMenuItem.Image")));
            this.magnifyMenuItem.LanguageKey = "editor_highlight_magnify";
            this.magnifyMenuItem.Name = "magnifyMenuItem";
            this.magnifyMenuItem.Size = new System.Drawing.Size(149, 22);
            this.magnifyMenuItem.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.MAGNIFICATION;
            this.magnifyMenuItem.Text = "Magnify";
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.Color.Transparent;
            this.btnFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFillColor.Image = ((System.Drawing.Image)(resources.GetObject("btnFillColor.Image")));
            this.btnFillColor.LanguageKey = "editor_backcolor";
            this.btnFillColor.Modification2 = true;
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.SelectedColor = System.Drawing.Color.Transparent;
            this.btnFillColor.Size = new System.Drawing.Size(36, 36);
            this.btnFillColor.Text = "Fill color";
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Transparent;
            this.btnLineColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLineColor.Image = ((System.Drawing.Image)(resources.GetObject("btnLineColor.Image")));
            this.btnLineColor.LanguageKey = "editor_forecolor";
            this.btnLineColor.Modification2 = true;
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.SelectedColor = System.Drawing.Color.Transparent;
            this.btnLineColor.Size = new System.Drawing.Size(36, 36);
            this.btnLineColor.Text = "Line color";
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.LanguageKey = "editor_thickness";
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(81, 36);
            this.lineThicknessLabel.Text = "Line thickness";
            // 
            // lineThicknessUpDown
            // 
            this.lineThicknessUpDown.DecimalPlaces = 0;
            this.lineThicknessUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineThicknessUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineThicknessUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lineThicknessUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lineThicknessUpDown.Name = "lineThicknessUpDown";
            this.lineThicknessUpDown.Size = new System.Drawing.Size(64, 36);
            this.lineThicknessUpDown.Text = "0";
            this.lineThicknessUpDown.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lineThicknessUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.lineThicknessUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // fontFamilyComboBox
            // 
            this.fontFamilyComboBox.AutoSize = false;
            this.fontFamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontFamilyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontFamilyComboBox.MaxDropDownItems = 20;
            this.fontFamilyComboBox.Name = "fontFamilyComboBox";
            this.fontFamilyComboBox.Padding = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.fontFamilyComboBox.Size = new System.Drawing.Size(210, 33);
            this.fontFamilyComboBox.Text = "Agency FB";
            this.fontFamilyComboBox.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.fontFamilyComboBox.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.LanguageKey = "editor_fontsize";
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(27, 36);
            this.fontSizeLabel.Text = "Size";
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.DecimalPlaces = 0;
            this.fontSizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontSizeUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.fontSizeUpDown.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.fontSizeUpDown.Name = "fontSizeUpDown";
            this.fontSizeUpDown.Size = new System.Drawing.Size(64, 36);
            this.fontSizeUpDown.Text = "12";
            this.fontSizeUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fontSizeUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.fontSizeUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // fontBoldButton
            // 
            this.fontBoldButton.CheckOnClick = true;
            this.fontBoldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontBoldButton.Image = ((System.Drawing.Image)(resources.GetObject("fontBoldButton.Image")));
            this.fontBoldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontBoldButton.LanguageKey = "editor_bold";
            this.fontBoldButton.Name = "fontBoldButton";
            this.fontBoldButton.Size = new System.Drawing.Size(36, 36);
            this.fontBoldButton.Text = "Bold";
            this.fontBoldButton.Click += new System.EventHandler(this.FontBoldButtonClick);
            // 
            // fontItalicButton
            // 
            this.fontItalicButton.CheckOnClick = true;
            this.fontItalicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontItalicButton.Image = ((System.Drawing.Image)(resources.GetObject("fontItalicButton.Image")));
            this.fontItalicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontItalicButton.LanguageKey = "editor_italic";
            this.fontItalicButton.Name = "fontItalicButton";
            this.fontItalicButton.Size = new System.Drawing.Size(36, 36);
            this.fontItalicButton.Text = "Italic";
            this.fontItalicButton.Click += new System.EventHandler(this.FontItalicButtonClick);
            // 
            // textHorizontalAlignmentButton
            // 
            this.textHorizontalAlignmentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textHorizontalAlignmentButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignLeftToolStripMenuItem,
            this.alignCenterToolStripMenuItem,
            this.alignRightToolStripMenuItem});
            this.textHorizontalAlignmentButton.Image = ((System.Drawing.Image)(resources.GetObject("textHorizontalAlignmentButton.Image")));
            this.textHorizontalAlignmentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textHorizontalAlignmentButton.LanguageKey = "editor_align_horizontal";
            this.textHorizontalAlignmentButton.Name = "textHorizontalAlignmentButton";
            this.textHorizontalAlignmentButton.SelectedTag = System.Drawing.StringAlignment.Center;
            this.textHorizontalAlignmentButton.Size = new System.Drawing.Size(45, 36);
            this.textHorizontalAlignmentButton.Tag = System.Drawing.StringAlignment.Center;
            this.textHorizontalAlignmentButton.Text = "Horizontal alignment";
            // 
            // alignLeftToolStripMenuItem
            // 
            this.alignLeftToolStripMenuItem.Icon = null;
            this.alignLeftToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignLeftToolStripMenuItem.Image")));
            this.alignLeftToolStripMenuItem.LanguageKey = "editor_align_left";
            this.alignLeftToolStripMenuItem.Name = "alignLeftToolStripMenuItem";
            this.alignLeftToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.alignLeftToolStripMenuItem.Tag = System.Drawing.StringAlignment.Near;
            this.alignLeftToolStripMenuItem.Text = "Left";
            // 
            // alignCenterToolStripMenuItem
            // 
            this.alignCenterToolStripMenuItem.Icon = null;
            this.alignCenterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignCenterToolStripMenuItem.Image")));
            this.alignCenterToolStripMenuItem.LanguageKey = "editor_align_center";
            this.alignCenterToolStripMenuItem.Name = "alignCenterToolStripMenuItem";
            this.alignCenterToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.alignCenterToolStripMenuItem.Tag = System.Drawing.StringAlignment.Center;
            this.alignCenterToolStripMenuItem.Text = "Center";
            // 
            // alignRightToolStripMenuItem
            // 
            this.alignRightToolStripMenuItem.Icon = null;
            this.alignRightToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignRightToolStripMenuItem.Image")));
            this.alignRightToolStripMenuItem.LanguageKey = "editor_align_right";
            this.alignRightToolStripMenuItem.Name = "alignRightToolStripMenuItem";
            this.alignRightToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.alignRightToolStripMenuItem.Tag = System.Drawing.StringAlignment.Far;
            this.alignRightToolStripMenuItem.Text = "Right";
            // 
            // textVerticalAlignmentButton
            // 
            this.textVerticalAlignmentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textVerticalAlignmentButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignTopToolStripMenuItem,
            this.alignMiddleToolStripMenuItem,
            this.alignBottomToolStripMenuItem});
            this.textVerticalAlignmentButton.Image = ((System.Drawing.Image)(resources.GetObject("textVerticalAlignmentButton.Image")));
            this.textVerticalAlignmentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textVerticalAlignmentButton.LanguageKey = "editor_align_vertical";
            this.textVerticalAlignmentButton.Name = "textVerticalAlignmentButton";
            this.textVerticalAlignmentButton.SelectedTag = System.Drawing.StringAlignment.Center;
            this.textVerticalAlignmentButton.Size = new System.Drawing.Size(45, 36);
            this.textVerticalAlignmentButton.Tag = System.Drawing.StringAlignment.Center;
            this.textVerticalAlignmentButton.Text = "Vertical alignment";
            // 
            // alignTopToolStripMenuItem
            // 
            this.alignTopToolStripMenuItem.Icon = null;
            this.alignTopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignTopToolStripMenuItem.Image")));
            this.alignTopToolStripMenuItem.LanguageKey = "editor_align_top";
            this.alignTopToolStripMenuItem.Name = "alignTopToolStripMenuItem";
            this.alignTopToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.alignTopToolStripMenuItem.Tag = System.Drawing.StringAlignment.Near;
            this.alignTopToolStripMenuItem.Text = "Top";
            // 
            // alignMiddleToolStripMenuItem
            // 
            this.alignMiddleToolStripMenuItem.Icon = null;
            this.alignMiddleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignMiddleToolStripMenuItem.Image")));
            this.alignMiddleToolStripMenuItem.LanguageKey = "editor_align_middle";
            this.alignMiddleToolStripMenuItem.Name = "alignMiddleToolStripMenuItem";
            this.alignMiddleToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.alignMiddleToolStripMenuItem.Tag = System.Drawing.StringAlignment.Center;
            this.alignMiddleToolStripMenuItem.Text = "Middle";
            // 
            // alignBottomToolStripMenuItem
            // 
            this.alignBottomToolStripMenuItem.Icon = null;
            this.alignBottomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignBottomToolStripMenuItem.Image")));
            this.alignBottomToolStripMenuItem.LanguageKey = "editor_align_bottom";
            this.alignBottomToolStripMenuItem.Name = "alignBottomToolStripMenuItem";
            this.alignBottomToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.alignBottomToolStripMenuItem.Tag = System.Drawing.StringAlignment.Far;
            this.alignBottomToolStripMenuItem.Text = "Bottom";
            // 
            // blurRadiusLabel
            // 
            this.blurRadiusLabel.LanguageKey = "editor_blur_radius";
            this.blurRadiusLabel.Name = "blurRadiusLabel";
            this.blurRadiusLabel.Size = new System.Drawing.Size(63, 15);
            this.blurRadiusLabel.Text = "Blur radius";
            // 
            // blurRadiusUpDown
            // 
            this.blurRadiusUpDown.DecimalPlaces = 0;
            this.blurRadiusUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blurRadiusUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blurRadiusUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.blurRadiusUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.blurRadiusUpDown.Name = "blurRadiusUpDown";
            this.blurRadiusUpDown.Size = new System.Drawing.Size(64, 32);
            this.blurRadiusUpDown.Text = "1";
            this.blurRadiusUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blurRadiusUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.blurRadiusUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.LanguageKey = "editor_brightness";
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(62, 15);
            this.brightnessLabel.Text = "Brightness";
            // 
            // brightnessUpDown
            // 
            this.brightnessUpDown.DecimalPlaces = 0;
            this.brightnessUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brightnessUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.brightnessUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.brightnessUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.brightnessUpDown.Name = "brightnessUpDown";
            this.brightnessUpDown.Size = new System.Drawing.Size(64, 32);
            this.brightnessUpDown.Text = "100";
            this.brightnessUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.brightnessUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.brightnessUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // previewQualityLabel
            // 
            this.previewQualityLabel.LanguageKey = "editor_preview_quality";
            this.previewQualityLabel.Name = "previewQualityLabel";
            this.previewQualityLabel.Size = new System.Drawing.Size(87, 15);
            this.previewQualityLabel.Text = "Preview quality";
            // 
            // previewQualityUpDown
            // 
            this.previewQualityUpDown.DecimalPlaces = 0;
            this.previewQualityUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.previewQualityUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.previewQualityUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.previewQualityUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.previewQualityUpDown.Name = "previewQualityUpDown";
            this.previewQualityUpDown.Size = new System.Drawing.Size(64, 32);
            this.previewQualityUpDown.Text = "50";
            this.previewQualityUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.previewQualityUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.previewQualityUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // magnificationFactorLabel
            // 
            this.magnificationFactorLabel.LanguageKey = "editor_magnification_factor";
            this.magnificationFactorLabel.Name = "magnificationFactorLabel";
            this.magnificationFactorLabel.Size = new System.Drawing.Size(115, 15);
            this.magnificationFactorLabel.Tag = ScreenLoad.Drawing.FilterContainer.PreparedFilter.MAGNIFICATION;
            this.magnificationFactorLabel.Text = "Magnification factor";
            // 
            // magnificationFactorUpDown
            // 
            this.magnificationFactorUpDown.DecimalPlaces = 0;
            this.magnificationFactorUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.magnificationFactorUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.magnificationFactorUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.magnificationFactorUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.magnificationFactorUpDown.Name = "magnificationFactorUpDown";
            this.magnificationFactorUpDown.Size = new System.Drawing.Size(40, 32);
            this.magnificationFactorUpDown.Text = "2";
            this.magnificationFactorUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.magnificationFactorUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.magnificationFactorUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // pixelSizeLabel
            // 
            this.pixelSizeLabel.LanguageKey = "editor_pixel_size";
            this.pixelSizeLabel.Name = "pixelSizeLabel";
            this.pixelSizeLabel.Size = new System.Drawing.Size(54, 15);
            this.pixelSizeLabel.Text = "Pixel size";
            // 
            // pixelSizeUpDown
            // 
            this.pixelSizeUpDown.DecimalPlaces = 0;
            this.pixelSizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pixelSizeUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pixelSizeUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pixelSizeUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pixelSizeUpDown.Name = "pixelSizeUpDown";
            this.pixelSizeUpDown.Size = new System.Drawing.Size(64, 32);
            this.pixelSizeUpDown.Text = "5";
            this.pixelSizeUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pixelSizeUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.pixelSizeUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // arrowHeadsLabel
            // 
            this.arrowHeadsLabel.LanguageKey = "editor_arrow_heads";
            this.arrowHeadsLabel.Name = "arrowHeadsLabel";
            this.arrowHeadsLabel.Size = new System.Drawing.Size(54, 15);
            this.arrowHeadsLabel.Text = "Pixel size";
            // 
            // arrowHeadsDropDownButton
            // 
            this.arrowHeadsDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arrowHeadsDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrowHeadStartMenuItem,
            this.arrowHeadEndMenuItem,
            this.arrowHeadBothMenuItem,
            this.arrowHeadNoneMenuItem});
            this.arrowHeadsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("arrowHeadsDropDownButton.Image")));
            this.arrowHeadsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowHeadsDropDownButton.LanguageKey = "editor_arrowheads";
            this.arrowHeadsDropDownButton.Name = "arrowHeadsDropDownButton";
            this.arrowHeadsDropDownButton.SelectedTag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.NONE;
            this.arrowHeadsDropDownButton.Size = new System.Drawing.Size(45, 36);
            this.arrowHeadsDropDownButton.Tag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.NONE;
            this.arrowHeadsDropDownButton.Text = "Arrow heads";
            // 
            // arrowHeadStartMenuItem
            // 
            this.arrowHeadStartMenuItem.Icon = null;
            this.arrowHeadStartMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arrowHeadStartMenuItem.Image")));
            this.arrowHeadStartMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowHeadStartMenuItem.LanguageKey = "editor_arrowheads_start";
            this.arrowHeadStartMenuItem.Name = "arrowHeadStartMenuItem";
            this.arrowHeadStartMenuItem.Size = new System.Drawing.Size(129, 22);
            this.arrowHeadStartMenuItem.Tag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.START_POINT;
            this.arrowHeadStartMenuItem.Text = "Start point";
            this.arrowHeadStartMenuItem.Click += new System.EventHandler(this.ArrowHeadsToolStripMenuItemClick);
            // 
            // arrowHeadEndMenuItem
            // 
            this.arrowHeadEndMenuItem.Icon = null;
            this.arrowHeadEndMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arrowHeadEndMenuItem.Image")));
            this.arrowHeadEndMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowHeadEndMenuItem.LanguageKey = "editor_arrowheads_end";
            this.arrowHeadEndMenuItem.Name = "arrowHeadEndMenuItem";
            this.arrowHeadEndMenuItem.Size = new System.Drawing.Size(129, 22);
            this.arrowHeadEndMenuItem.Tag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.END_POINT;
            this.arrowHeadEndMenuItem.Text = "End point";
            this.arrowHeadEndMenuItem.Click += new System.EventHandler(this.ArrowHeadsToolStripMenuItemClick);
            // 
            // arrowHeadBothMenuItem
            // 
            this.arrowHeadBothMenuItem.Icon = null;
            this.arrowHeadBothMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arrowHeadBothMenuItem.Image")));
            this.arrowHeadBothMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowHeadBothMenuItem.LanguageKey = "editor_arrowheads_both";
            this.arrowHeadBothMenuItem.Name = "arrowHeadBothMenuItem";
            this.arrowHeadBothMenuItem.Size = new System.Drawing.Size(129, 22);
            this.arrowHeadBothMenuItem.Tag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.BOTH;
            this.arrowHeadBothMenuItem.Text = "Both";
            this.arrowHeadBothMenuItem.Click += new System.EventHandler(this.ArrowHeadsToolStripMenuItemClick);
            // 
            // arrowHeadNoneMenuItem
            // 
            this.arrowHeadNoneMenuItem.Icon = null;
            this.arrowHeadNoneMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("arrowHeadNoneMenuItem.Image")));
            this.arrowHeadNoneMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arrowHeadNoneMenuItem.LanguageKey = "editor_arrowheads_none";
            this.arrowHeadNoneMenuItem.Name = "arrowHeadNoneMenuItem";
            this.arrowHeadNoneMenuItem.Size = new System.Drawing.Size(129, 22);
            this.arrowHeadNoneMenuItem.Tag = ScreenLoad.Drawing.ArrowContainer.ArrowHeadCombination.NONE;
            this.arrowHeadNoneMenuItem.Text = "None";
            this.arrowHeadNoneMenuItem.Click += new System.EventHandler(this.ArrowHeadsToolStripMenuItemClick);
            // 
            // shadowButton
            // 
            this.shadowButton.CheckOnClick = true;
            this.shadowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shadowButton.Image = ((System.Drawing.Image)(resources.GetObject("shadowButton.Image")));
            this.shadowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shadowButton.LanguageKey = "editor_shadow";
            this.shadowButton.Name = "shadowButton";
            this.shadowButton.Size = new System.Drawing.Size(36, 36);
            this.shadowButton.Text = "Drop shadow";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // btnConfirm
            // 
            this.btnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.LanguageKey = "editor_confirm";
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(36, 36);
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirmClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.LanguageKey = "editor_cancel";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // counterLabel
            // 
            this.counterLabel.LanguageKey = "editor_counter_startvalue";
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(0, 0);
            // 
            // counterUpDown
            // 
            this.counterUpDown.DecimalPlaces = 0;
            this.counterUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.counterUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.counterUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.counterUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.counterUpDown.Name = "counterUpDown";
            this.counterUpDown.Size = new System.Drawing.Size(64, 32);
            this.counterUpDown.Text = "1";
            this.counterUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.counterUpDown.GotFocus += new System.EventHandler(this.ToolBarFocusableElementGotFocus);
            this.counterUpDown.LostFocus += new System.EventHandler(this.ToolBarFocusableElementLostFocus);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dimensionsLabel,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 39);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 359);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 353);
            this.panel1.TabIndex = 2;
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
            this.toolsToolStrip.Size = new System.Drawing.Size(40, 359);
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
            this.btnObfuscate.Size = new System.Drawing.Size(35, 36);
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
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
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
            this.toolStripSeparator9.Size = new System.Drawing.Size(57, 6);
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
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
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
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
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
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
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
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
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
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
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
            this.preferencesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preferencesToolStripMenuItem.Image")));
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
            this.addRectangleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addRectangleToolStripMenuItem.Image")));
            this.addRectangleToolStripMenuItem.LanguageKey = "editor_drawrectangle";
            this.addRectangleToolStripMenuItem.Name = "addRectangleToolStripMenuItem";
            this.addRectangleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addRectangleToolStripMenuItem.Text = "Draw rectangle (R)";
            this.addRectangleToolStripMenuItem.Click += new System.EventHandler(this.AddRectangleToolStripMenuItemClick);
            // 
            // addEllipseToolStripMenuItem
            // 
            this.addEllipseToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addEllipseToolStripMenuItem.Icon")));
            this.addEllipseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addEllipseToolStripMenuItem.Image")));
            this.addEllipseToolStripMenuItem.LanguageKey = "editor_drawellipse";
            this.addEllipseToolStripMenuItem.Name = "addEllipseToolStripMenuItem";
            this.addEllipseToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addEllipseToolStripMenuItem.Text = "Draw ellipse (E)";
            this.addEllipseToolStripMenuItem.Click += new System.EventHandler(this.AddEllipseToolStripMenuItemClick);
            // 
            // drawLineToolStripMenuItem
            // 
            this.drawLineToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawLineToolStripMenuItem.Icon")));
            this.drawLineToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drawLineToolStripMenuItem.Image")));
            this.drawLineToolStripMenuItem.LanguageKey = "editor_drawline";
            this.drawLineToolStripMenuItem.Name = "drawLineToolStripMenuItem";
            this.drawLineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawLineToolStripMenuItem.Text = "Draw line (L)";
            this.drawLineToolStripMenuItem.Click += new System.EventHandler(this.DrawLineToolStripMenuItemClick);
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawArrowToolStripMenuItem.Icon")));
            this.drawArrowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drawArrowToolStripMenuItem.Image")));
            this.drawArrowToolStripMenuItem.LanguageKey = "editor_drawarrow";
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow (A)";
            this.drawArrowToolStripMenuItem.Click += new System.EventHandler(this.DrawArrowToolStripMenuItemClick);
            // 
            // drawFreehandToolStripMenuItem
            // 
            this.drawFreehandToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("drawFreehandToolStripMenuItem.Icon")));
            this.drawFreehandToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drawFreehandToolStripMenuItem.Image")));
            this.drawFreehandToolStripMenuItem.LanguageKey = "editor_drawfreehand";
            this.drawFreehandToolStripMenuItem.Name = "drawFreehandToolStripMenuItem";
            this.drawFreehandToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.drawFreehandToolStripMenuItem.Text = "Draw freehand (F)";
            this.drawFreehandToolStripMenuItem.Click += new System.EventHandler(this.DrawFreehandToolStripMenuItemClick);
            // 
            // addTextBoxToolStripMenuItem
            // 
            this.addTextBoxToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addTextBoxToolStripMenuItem.Icon")));
            this.addTextBoxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTextBoxToolStripMenuItem.Image")));
            this.addTextBoxToolStripMenuItem.LanguageKey = "editor_drawtextbox";
            this.addTextBoxToolStripMenuItem.Name = "addTextBoxToolStripMenuItem";
            this.addTextBoxToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addTextBoxToolStripMenuItem.Text = "Add textbox (T)";
            this.addTextBoxToolStripMenuItem.Click += new System.EventHandler(this.AddTextBoxToolStripMenuItemClick);
            // 
            // addSpeechBubbleToolStripMenuItem
            // 
            this.addSpeechBubbleToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addSpeechBubbleToolStripMenuItem.Icon")));
            this.addSpeechBubbleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addSpeechBubbleToolStripMenuItem.Image")));
            this.addSpeechBubbleToolStripMenuItem.LanguageKey = "editor_speechbubble";
            this.addSpeechBubbleToolStripMenuItem.Name = "addSpeechBubbleToolStripMenuItem";
            this.addSpeechBubbleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addSpeechBubbleToolStripMenuItem.Text = "Add speechbubble (S)";
            this.addSpeechBubbleToolStripMenuItem.Click += new System.EventHandler(this.AddSpeechBubbleToolStripMenuItemClick);
            // 
            // addCounterToolStripMenuItem
            // 
            this.addCounterToolStripMenuItem.Icon = ((System.Drawing.Icon)(resources.GetObject("addCounterToolStripMenuItem.Icon")));
            this.addCounterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCounterToolStripMenuItem.Image")));
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
            this.removeObjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeObjectToolStripMenuItem.Image")));
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
            this.helpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem1.Image")));
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
            this.propertiesToolStrip.ResumeLayout(false);
            this.propertiesToolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolsToolStrip.ResumeLayout(false);
            this.toolsToolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.destinationsToolStrip.ResumeLayout(false);
            this.destinationsToolStrip.PerformLayout();
            this.fileSavedStatusContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignRightToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignCenterToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignLeftToolStripMenuItem;
        private ScreenLoad.Controls.BindableToolStripDropDownButton textHorizontalAlignmentButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignMiddleToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignBottomToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem alignTopToolStripMenuItem;
        private ScreenLoad.Controls.BindableToolStripDropDownButton textVerticalAlignmentButton;
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
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem grayscaleHighlightMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem areaHighlightMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem textHighlightMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem magnifyMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem arrowHeadStartMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem arrowHeadEndMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem arrowHeadBothMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem arrowHeadNoneMenuItem;
        private ScreenLoad.Controls.BindableToolStripButton btnCancel;
        private ScreenLoad.Controls.BindableToolStripButton btnConfirm;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem selectAllToolStripMenuItem;
        private ScreenLoad.Controls.BindableToolStripDropDownButton highlightModeButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem pixelizeToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem blurToolStripMenuItem;
        private ScreenLoad.Controls.BindableToolStripDropDownButton obfuscateModeButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripButton btnHighlight;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem loadElementsToolStripMenuItem;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem saveElementsToolStripMenuItem;
        private ScreenLoad.Controls.FontFamilyComboBox fontFamilyComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private ScreenLoad.Controls.BindableToolStripButton shadowButton;
        private ScreenLoad.Controls.BindableToolStripButton fontItalicButton;
        private ScreenLoad.Controls.BindableToolStripButton fontBoldButton;
        private ScreenLoad.Controls.ToolStripNumericUpDown fontSizeUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel fontSizeLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown brightnessUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel brightnessLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem pluginToolStripMenuItem;
        private ScreenLoad.Controls.BindableToolStripDropDownButton arrowHeadsDropDownButton;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel arrowHeadsLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown pixelSizeUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel pixelSizeLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown magnificationFactorUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel magnificationFactorLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown previewQualityUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel previewQualityLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown blurRadiusUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel blurRadiusLabel;
        private ScreenLoad.Controls.ToolStripEx propertiesToolStrip;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel lineThicknessLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown lineThicknessUpDown;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripLabel counterLabel;
        private ScreenLoad.Controls.ToolStripNumericUpDown counterUpDown;
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
        private ScreenLoad.Controls.ToolStripColorButton btnFillColor;
        private ScreenLoad.Controls.ToolStripColorButton btnLineColor;
        private ScreenLoadPlugin.Controls.ScreenLoadToolStripMenuItem autoCropToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
    }
}