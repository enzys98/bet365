using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CEBet365Placer.Properties;
using Siticone.Desktop.UI.WinForms;
using Siticone.Desktop.UI.WinForms.Enums;

namespace CEBet365Placer;

public class frmbigstake : Form
{
	private IContainer components;

	private SiticonePanel DragPanel;

	private SiticonePictureBox siticonePictureBox2;

	private SiticoneHtmlLabel siticoneHtmlLabel12;

	private SiticoneControlBox siticoneControlBox2;

	private SiticoneControlBox siticoneControlBox1;

	private SiticoneButton btnCancel;

	private SiticoneButton btnSave;

	private SiticoneTextBox txtPassBig;

	private SiticoneTextBox txtUserBig;

	private SiticoneGradientPanel siticoneGradientPanel1;

	private SiticoneTextBox txtMassId;

	private SiticoneTextBox txtRosId;

	public frmbigstake()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		InitializeComponent();
		new SiticoneShadowForm((Form)(object)this);
		new SiticoneDragControl((Control)(object)DragPanel);
		txtUserBig.Text = Setting.instance.bigStakUsername;
		txtPassBig.Text = Setting.instance.bigStakePass;
		txtMassId.Text = Setting.instance.massId;
		txtRosId.Text = Setting.instance.rossId;
	}

	private void btnStart_Click(object sender, EventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(txtUserBig.Text))
		{
			MessageBox.Show("Pls input BigStake username!");
			txtUserBig.Focus();
			return;
		}
		if (string.IsNullOrEmpty(txtPassBig.Text))
		{
			MessageBox.Show("Pls input BigStake password!");
			txtPassBig.Focus();
			return;
		}
		if (string.IsNullOrEmpty(txtMassId.Text))
		{
			MessageBox.Show("Pls input Masaniello Id");
			txtMassId.Focus();
			return;
		}
		if (string.IsNullOrEmpty(txtRosId.Text))
		{
			MessageBox.Show("Pls input Roserpina Id");
			txtRosId.Focus();
			return;
		}
		Setting.instance.bigStakUsername = txtUserBig.Text.Trim();
		Setting.instance.bigStakePass = txtPassBig.Text.Trim();
		Setting.instance.massId = txtMassId.Text.Trim();
		Setting.instance.rossId = txtRosId.Text.Trim();
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void frmbigstake_Load(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected O, but got Unknown
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Expected O, but got Unknown
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Expected O, but got Unknown
		//IL_0d30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3a: Expected O, but got Unknown
		//IL_0f5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f69: Expected O, but got Unknown
		DragPanel = new SiticonePanel();
		siticonePictureBox2 = new SiticonePictureBox();
		siticoneHtmlLabel12 = new SiticoneHtmlLabel();
		siticoneControlBox2 = new SiticoneControlBox();
		siticoneControlBox1 = new SiticoneControlBox();
		btnCancel = new SiticoneButton();
		btnSave = new SiticoneButton();
		txtPassBig = new SiticoneTextBox();
		txtUserBig = new SiticoneTextBox();
		siticoneGradientPanel1 = new SiticoneGradientPanel();
		txtMassId = new SiticoneTextBox();
		txtRosId = new SiticoneTextBox();
		((Control)DragPanel).SuspendLayout();
		((ISupportInitialize)siticonePictureBox2).BeginInit();
		((Control)siticoneGradientPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)DragPanel).BackColor = Color.FromArgb(44, 46, 86);
		((Control)DragPanel).Controls.Add((Control)(object)siticonePictureBox2);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneHtmlLabel12);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneControlBox2);
		((Control)DragPanel).Controls.Add((Control)(object)siticoneControlBox1);
		DragPanel.CustomBorderColor = Color.FromArgb(62, 65, 121);
		DragPanel.CustomBorderThickness = new Padding(0, 0, 0, 1);
		((Control)DragPanel).Dock = (DockStyle)1;
		DragPanel.FillColor = Color.FromArgb(44, 46, 86);
		((Control)DragPanel).Location = new Point(0, 0);
		((Control)DragPanel).Name = "DragPanel";
		((Control)DragPanel).Size = new Size(412, 50);
		((Control)DragPanel).TabIndex = 54;
		((Control)siticonePictureBox2).Enabled = false;
		siticonePictureBox2.FillColor = Color.Transparent;
		((PictureBox)siticonePictureBox2).Image = (Image)(object)Resources.settings;
		siticonePictureBox2.ImageRotate = 0f;
		((Control)siticonePictureBox2).Location = new Point(11, 12);
		((Control)siticonePictureBox2).Name = "siticonePictureBox2";
		((Control)siticonePictureBox2).Size = new Size(30, 30);
		((PictureBox)siticonePictureBox2).SizeMode = (PictureBoxSizeMode)4;
		((PictureBox)siticonePictureBox2).TabIndex = 6;
		((PictureBox)siticonePictureBox2).TabStop = false;
		((Control)siticoneHtmlLabel12).BackColor = Color.Transparent;
		((Control)siticoneHtmlLabel12).Enabled = false;
		siticoneHtmlLabel12.Font = new Font("Bahnschrift SemiBold SemiConden", 20f, (FontStyle)1);
		siticoneHtmlLabel12.ForeColor = Color.White;
		((Control)siticoneHtmlLabel12).Location = new Point(12, 8);
		((Control)siticoneHtmlLabel12).Name = "siticoneHtmlLabel12";
		((Control)siticoneHtmlLabel12).Size = new Size(3, 2);
		((Control)siticoneHtmlLabel12).TabIndex = 5;
		((Control)siticoneHtmlLabel12).Text = null;
		((Control)siticoneControlBox2).Anchor = (AnchorStyles)9;
		siticoneControlBox2.ControlBoxType = (ControlBoxType)0;
		((Control)siticoneControlBox2).Cursor = Cursors.Hand;
		siticoneControlBox2.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox2.HoverState.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox2.HoverState.IconColor = Color.Red;
		siticoneControlBox2.IconColor = Color.LightGray;
		((Control)siticoneControlBox2).Location = new Point(311, 2);
		((Control)siticoneControlBox2).Name = "siticoneControlBox2";
		siticoneControlBox2.PressedColor = Color.White;
		((Control)siticoneControlBox2).Size = new Size(49, 45);
		((Control)siticoneControlBox2).TabIndex = 4;
		((Control)siticoneControlBox1).Anchor = (AnchorStyles)9;
		((Control)siticoneControlBox1).Cursor = Cursors.Hand;
		siticoneControlBox1.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox1.HoverState.FillColor = Color.FromArgb(44, 46, 86);
		siticoneControlBox1.HoverState.IconColor = Color.Red;
		siticoneControlBox1.IconColor = Color.LightGray;
		((Control)siticoneControlBox1).Location = new Point(360, 2);
		((Control)siticoneControlBox1).Name = "siticoneControlBox1";
		siticoneControlBox1.PressedColor = Color.White;
		((Control)siticoneControlBox1).Size = new Size(49, 45);
		((Control)siticoneControlBox1).TabIndex = 0;
		btnCancel.DisabledState.BorderColor = Color.DarkGray;
		btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
		btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnCancel.FillColor = Color.FromArgb(192, 64, 0);
		((Control)btnCancel).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnCancel).ForeColor = Color.White;
		((Control)btnCancel).Location = new Point(290, 320);
		((Control)btnCancel).Name = "btnCancel";
		((Control)btnCancel).Size = new Size(87, 33);
		((Control)btnCancel).TabIndex = 59;
		((Control)btnCancel).Text = "Cancel";
		((Control)btnCancel).Click += btnCancel_Click;
		btnSave.DisabledState.BorderColor = Color.DarkGray;
		btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
		btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnSave.FillColor = Color.RoyalBlue;
		((Control)btnSave).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnSave).ForeColor = Color.White;
		((Control)btnSave).Location = new Point(195, 320);
		((Control)btnSave).Name = "btnSave";
		((Control)btnSave).Size = new Size(89, 33);
		((Control)btnSave).TabIndex = 58;
		((Control)btnSave).Text = "Save";
		((Control)btnSave).Click += btnStart_Click;
		txtPassBig.Animated = true;
		txtPassBig.BorderColor = Color.FromArgb(224, 224, 224);
		txtPassBig.BorderThickness = 2;
		((Control)txtPassBig).Cursor = Cursors.IBeam;
		txtPassBig.DefaultText = "";
		txtPassBig.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtPassBig.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtPassBig.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtPassBig.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtPassBig.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtPassBig.FocusedState.FillColor = Color.White;
		txtPassBig.Font = new Font("Segoe UI", 9f);
		txtPassBig.ForeColor = Color.Black;
		txtPassBig.HoverState.BorderColor = Color.Silver;
		txtPassBig.HoverState.FillColor = Color.White;
		txtPassBig.HoverState.ForeColor = Color.DimGray;
		txtPassBig.IconLeft = (Image)(object)Resources.password_idle;
		txtPassBig.IconLeftOffset = new Point(10, 0);
		txtPassBig.IconLeftSize = new Size(16, 18);
		((Control)txtPassBig).Location = new Point(35, 72);
		((Control)txtPassBig).Name = "txtPassBig";
		txtPassBig.PasswordChar = '●';
		txtPassBig.PlaceholderText = "Enter your BigStake Password";
		txtPassBig.SelectedText = "";
		((Control)txtPassBig).Size = new Size(283, 36);
		((Control)txtPassBig).TabIndex = 6;
		txtPassBig.TextOffset = new Point(5, 0);
		txtPassBig.UseSystemPasswordChar = true;
		txtUserBig.Animated = true;
		txtUserBig.BorderColor = Color.FromArgb(224, 224, 224);
		txtUserBig.BorderThickness = 2;
		((Control)txtUserBig).Cursor = Cursors.IBeam;
		txtUserBig.DefaultText = "";
		txtUserBig.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtUserBig.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtUserBig.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtUserBig.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtUserBig.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtUserBig.FocusedState.FillColor = Color.White;
		txtUserBig.Font = new Font("Segoe UI", 9f);
		txtUserBig.ForeColor = Color.Black;
		txtUserBig.HoverState.BorderColor = Color.Silver;
		txtUserBig.HoverState.FillColor = Color.White;
		txtUserBig.HoverState.ForeColor = Color.DimGray;
		txtUserBig.IconLeft = (Image)(object)Resources.username_idle;
		txtUserBig.IconLeftOffset = new Point(10, 0);
		txtUserBig.IconLeftSize = new Size(17, 17);
		((Control)txtUserBig).Location = new Point(35, 30);
		((Control)txtUserBig).Name = "txtUserBig";
		txtUserBig.PasswordChar = '\0';
		txtUserBig.PlaceholderText = "Enter your BigStake Username";
		txtUserBig.SelectedText = "";
		((Control)txtUserBig).Size = new Size(283, 36);
		((Control)txtUserBig).TabIndex = 5;
		txtUserBig.TextOffset = new Point(5, 0);
		((Control)siticoneGradientPanel1).BackColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtRosId);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtMassId);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtUserBig);
		((Control)siticoneGradientPanel1).Controls.Add((Control)(object)txtPassBig);
		((Control)siticoneGradientPanel1).Location = new Point(33, 82);
		((Control)siticoneGradientPanel1).Name = "siticoneGradientPanel1";
		((Control)siticoneGradientPanel1).Size = new Size(344, 222);
		((Control)siticoneGradientPanel1).TabIndex = 60;
		txtMassId.Animated = true;
		txtMassId.BorderColor = Color.FromArgb(224, 224, 224);
		txtMassId.BorderThickness = 2;
		((Control)txtMassId).Cursor = Cursors.IBeam;
		txtMassId.DefaultText = "";
		txtMassId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtMassId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtMassId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtMassId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtMassId.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtMassId.FocusedState.FillColor = Color.White;
		txtMassId.Font = new Font("Segoe UI", 9f);
		txtMassId.ForeColor = Color.Black;
		txtMassId.HoverState.BorderColor = Color.Silver;
		txtMassId.HoverState.FillColor = Color.White;
		txtMassId.HoverState.ForeColor = Color.DimGray;
		txtMassId.IconLeftOffset = new Point(10, 0);
		txtMassId.IconLeftSize = new Size(16, 18);
		((Control)txtMassId).Location = new Point(35, 114);
		((Control)txtMassId).Name = "txtMassId";
		txtMassId.PasswordChar = '\0';
		txtMassId.PlaceholderText = "Enter Masaniello  Id";
		txtMassId.SelectedText = "";
		((Control)txtMassId).Size = new Size(283, 36);
		((Control)txtMassId).TabIndex = 8;
		txtMassId.TextOffset = new Point(5, 0);
		txtRosId.Animated = true;
		txtRosId.BorderColor = Color.FromArgb(224, 224, 224);
		txtRosId.BorderThickness = 2;
		((Control)txtRosId).Cursor = Cursors.IBeam;
		txtRosId.DefaultText = "";
		txtRosId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtRosId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtRosId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtRosId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtRosId.FocusedState.BorderColor = Color.FromArgb(81, 67, 163);
		txtRosId.FocusedState.FillColor = Color.White;
		txtRosId.Font = new Font("Segoe UI", 9f);
		txtRosId.ForeColor = Color.Black;
		txtRosId.HoverState.BorderColor = Color.Silver;
		txtRosId.HoverState.FillColor = Color.White;
		txtRosId.HoverState.ForeColor = Color.DimGray;
		txtRosId.IconLeftOffset = new Point(10, 0);
		txtRosId.IconLeftSize = new Size(16, 18);
		((Control)txtRosId).Location = new Point(35, 156);
		((Control)txtRosId).Name = "txtRosId";
		txtRosId.PasswordChar = '\0';
		txtRosId.PlaceholderText = "Enter Roserpina  Id";
		txtRosId.SelectedText = "";
		((Control)txtRosId).Size = new Size(283, 36);
		((Control)txtRosId).TabIndex = 9;
		txtRosId.TextOffset = new Point(5, 0);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(44, 46, 86);
		((Form)this).ClientSize = new Size(412, 374);
		((Control)this).Controls.Add((Control)(object)siticoneGradientPanel1);
		((Control)this).Controls.Add((Control)(object)btnCancel);
		((Control)this).Controls.Add((Control)(object)btnSave);
		((Control)this).Controls.Add((Control)(object)DragPanel);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = "frmbigstake";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Load += frmbigstake_Load;
		((Control)DragPanel).ResumeLayout(false);
		((Control)DragPanel).PerformLayout();
		((ISupportInitialize)siticonePictureBox2).EndInit();
		((Control)siticoneGradientPanel1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
