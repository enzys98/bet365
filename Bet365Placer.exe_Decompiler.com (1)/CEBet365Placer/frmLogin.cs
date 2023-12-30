using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using CEBet365Placer.Properties;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace CEBet365Placer;

public class frmLogin : Form
{
	private IContainer components;

	private SiticonePanel siticonePanel1;

	private SiticoneButton btnLogin;

	private SiticoneTextBox txtPass;

	public frmLogin()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		InitializeComponent();
		new SiticoneShadowForm((Form)(object)this);
		new SiticoneDragControl((Control)(object)siticonePanel1);
	}

	private void txtPass_TextChanged(object sender, EventArgs e)
	{
		EnableButton();
	}

	private void EnableButton()
	{
		if (!string.IsNullOrWhiteSpace(((TextBox)txtPass).Text))
		{
			((Control)btnLogin).Enabled = true;
		}
		else
		{
			((Control)btnLogin).Enabled = false;
		}
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		string errorMessage = string.Empty;
		if (loginToServer(((TextBox)txtPass).Text, ref errorMessage))
		{
			((Control)this).Hide();
			((Control)new Form1(((TextBox)txtPass).Text)).Show();
		}
		else
		{
			MessageBox.Show(errorMessage);
			((TextBox)txtPass).Focus();
		}
	}

	private bool loginToServer(string license, ref string errorMessage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		bool result = false;
		try
		{
			HttpClient val = new HttpClient();
			StringContent val2 = new StringContent(((object)new JObject { ["license"] = JToken.op_Implicit(license) }).ToString(), Encoding.UTF8, "application/json");
			JObject val3 = JObject.Parse(val.PostAsync("http://173.212.250.148:9002/interface/login", (HttpContent)(object)val2).Result.Content.ReadAsStringAsync().Result);
			if (((object)val3["success"]).ToString() == "True")
			{
				result = true;
			}
			else
			{
				errorMessage = ((object)val3["message"]).ToString();
			}
		}
		catch (Exception)
		{
			errorMessage = "Network Connection Failed! Try within few minutes!";
		}
		return result;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLogin));
		siticonePanel1 = new SiticonePanel();
		btnLogin = new SiticoneButton();
		txtPass = new SiticoneTextBox();
		((Control)siticonePanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)siticonePanel1).BackColor = Color.FromArgb(44, 46, 86);
		siticonePanel1.BorderColor = Color.FromArgb(224, 224, 224);
		((Control)siticonePanel1).Controls.Add((Control)(object)btnLogin);
		((Control)siticonePanel1).Controls.Add((Control)(object)txtPass);
		((Control)siticonePanel1).Location = new Point(-3, -1);
		((Control)siticonePanel1).Name = "siticonePanel1";
		siticonePanel1.ShadowDecoration.Parent = (Control)(object)siticonePanel1;
		((Control)siticonePanel1).Size = new Size(405, 195);
		((Control)siticonePanel1).TabIndex = 1;
		btnLogin.BorderRadius = 2;
		btnLogin.BorderThickness = 1;
		btnLogin.CheckedState.Parent = (CustomButtonBase)(object)btnLogin;
		((Control)btnLogin).Cursor = Cursors.Hand;
		btnLogin.CustomImages.Parent = (CustomButtonBase)(object)btnLogin;
		((Control)btnLogin).Enabled = false;
		btnLogin.FillColor = Color.DarkCyan;
		((Control)btnLogin).Font = new Font("Segoe UI", 9f);
		((Control)btnLogin).ForeColor = Color.White;
		btnLogin.HoveredState.Parent = (CustomButtonBase)(object)btnLogin;
		((Control)btnLogin).Location = new Point(58, 107);
		((Control)btnLogin).Name = "btnLogin";
		btnLogin.ShadowDecoration.Parent = (Control)(object)btnLogin;
		((Control)btnLogin).Size = new Size(284, 37);
		((Control)btnLogin).TabIndex = 5;
		((Control)btnLogin).Text = "LOGIN";
		((Control)btnLogin).Click += btnLogin_Click;
		((Control)txtPass).Cursor = Cursors.IBeam;
		((TextBox)txtPass).DefaultText = "";
		txtPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtPass.DisabledState.Parent = (TextBox)(object)txtPass;
		txtPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtPass.FocusedState.Parent = (TextBox)(object)txtPass;
		txtPass.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtPass.HoveredState.Parent = (TextBox)(object)txtPass;
		txtPass.IconLeft = (Image)(object)Resources.password_idle;
		((Control)txtPass).Location = new Point(58, 54);
		((Control)txtPass).Name = "txtPass";
		((TextBox)txtPass).PasswordChar = '\0';
		txtPass.PlaceholderText = "Input License Key";
		((TextBox)txtPass).SelectedText = "";
		txtPass.ShadowDecoration.Parent = (Control)(object)txtPass;
		((Control)txtPass).Size = new Size(284, 36);
		((Control)txtPass).TabIndex = 3;
		((TextBox)txtPass).TextChanged += txtPass_TextChanged;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(401, 194);
		((Control)this).Controls.Add((Control)(object)siticonePanel1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "frmLogin";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)siticonePanel1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
