using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CEBet365Placer.Properties;
using Siticone.Desktop.UI.WinForms;
using Siticone.Desktop.UI.WinForms.Enums;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Suite;

namespace CEBet365Placer;

public class frmSet : Form
{
	private IContainer components;

	private SiticonePanel DragPanel;

	private SiticoneHtmlLabel siticoneHtmlLabel12;

	private SiticoneControlBox siticoneControlBox2;

	private SiticoneControlBox siticoneControlBox1;

	private SiticonePictureBox siticonePictureBox2;

	private SiticoneGroupBox siticoneGroupBox1;

	private SiticoneHtmlLabel siticoneHtmlLabel2;

	private SiticoneTextBox txtOdds25;

	private SiticoneTextBox txtStake25;

	private SiticoneHtmlLabel siticoneHtmlLabel1;

	private SiticoneTextBox txtStake15;

	private SiticoneTextBox txtOdds05;

	private SiticoneTextBox txtStake05;

	private SiticoneHtmlLabel siticoneHtmlLabel3;

	private SiticoneTextBox txtOdds65;

	private SiticoneTextBox txtStake65;

	private SiticoneHtmlLabel siticoneHtmlLabel7;

	private SiticoneTextBox txtOdds55;

	private SiticoneTextBox txtStake55;

	private SiticoneHtmlLabel siticoneHtmlLabel6;

	private SiticoneTextBox txtOdds45;

	private SiticoneTextBox txtStake45;

	private SiticoneHtmlLabel siticoneHtmlLabel5;

	private SiticoneTextBox txtOdds35;

	private SiticoneTextBox txtStake35;

	private SiticoneHtmlLabel siticoneHtmlLabel4;

	private SiticoneTextBox txtOdds75;

	private SiticoneTextBox txtStake75;

	private SiticoneHtmlLabel siticoneHtmlLabel8;

	private SiticoneGroupBox siticoneGroupBox2;

	private SiticoneTextBox txtOdds25HT;

	private SiticoneTextBox txtStake25HT;

	private SiticoneTextBox txtOdds15HT;

	private SiticoneTextBox txtStake15HT;

	private SiticoneTextBox txtOdds05HT;

	private SiticoneTextBox txtStake05HT;

	private SiticoneHtmlLabel siticoneHtmlLabel17;

	private SiticoneHtmlLabel siticoneHtmlLabel15;

	private SiticoneHtmlLabel siticoneHtmlLabel16;

	private SiticoneGroupBox siticoneGroupBox3;

	private SiticoneTextBox txtodds80m;

	private SiticoneTextBox txtStake80m;

	private SiticoneHtmlLabel siticoneHtmlLabel9;

	private SiticoneTextBox txtodds70m;

	private SiticoneTextBox txtStake70m;

	private SiticoneHtmlLabel siticoneHtmlLabel10;

	private SiticoneTextBox txtodds60m;

	private SiticoneTextBox txtStake60m;

	private SiticoneHtmlLabel siticoneHtmlLabel11;

	private SiticoneTextBox txtodds50m;

	private SiticoneTextBox txtStake50m;

	private SiticoneHtmlLabel siticoneHtmlLabel13;

	private SiticoneTextBox txtodds40m;

	private SiticoneTextBox txtStake40m;

	private SiticoneHtmlLabel siticoneHtmlLabel14;

	private SiticoneHtmlLabel siticoneHtmlLabel18;

	private SiticoneTextBox txtodds30m;

	private SiticoneTextBox txtStake30m;

	private SiticoneHtmlLabel siticoneHtmlLabel19;

	private SiticoneTextBox txtodds20m;

	private SiticoneTextBox txtStake20m;

	private SiticoneTextBox txtodds10m;

	private SiticoneTextBox txtStake10m;

	private SiticoneHtmlLabel siticoneHtmlLabel20;

	private SiticoneGroupBox siticoneGroupBox4;

	private SiticoneHtmlLabel siticoneHtmlLabel22;

	private SiticoneHtmlLabel siticoneHtmlLabel21;

	private SiticoneTextBox txtOddsU45;

	private SiticoneTextBox txtStakeU45;

	private SiticoneTextBox txtOddsU35;

	private SiticoneTextBox txtStakeU35;

	private SiticoneTextBox txtOddsU25;

	private SiticoneTextBox txtStakeU25;

	private SiticoneHtmlLabel siticoneHtmlLabel23;

	private SiticoneGroupBox siticoneGroupBox5;

	private SiticoneHtmlLabel siticoneHtmlLabel24;

	private SiticoneHtmlLabel siticoneHtmlLabel25;

	private SiticoneTextBox txtOddsGoal;

	private SiticoneTextBox txtStakeGoal;

	private SiticoneTextBox txtOddsAGoal;

	private SiticoneTextBox txtStakeAGoal;

	private SiticoneTextBox txtOddshGoal;

	private SiticoneTextBox txtStakehGoal;

	private SiticoneHtmlLabel siticoneHtmlLabel26;

	private SiticoneButton btnCancel;

	private SiticoneButton btnSave;

	private SiticoneTextBox txtOdds15;

	public frmSet()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		InitializeComponent();
		new SiticoneShadowForm((Form)(object)this);
		new SiticoneDragControl((Control)(object)DragPanel);
		((TextBox)txtStake05).Text = Setting.instance.stake05.ToString();
		((TextBox)txtOdds05).Text = Setting.instance.odds05.ToString();
		((TextBox)txtStake15).Text = Setting.instance.stake15.ToString();
		((TextBox)txtOdds15).Text = Setting.instance.odds15.ToString();
		((TextBox)txtStake25).Text = Setting.instance.stake25.ToString();
		((TextBox)txtOdds25).Text = Setting.instance.odds25.ToString();
		((TextBox)txtStake35).Text = Setting.instance.stake35.ToString();
		((TextBox)txtOdds35).Text = Setting.instance.odds35.ToString();
		((TextBox)txtStake45).Text = Setting.instance.stake45.ToString();
		((TextBox)txtOdds45).Text = Setting.instance.odds45.ToString();
		((TextBox)txtStake55).Text = Setting.instance.stake55.ToString();
		((TextBox)txtOdds55).Text = Setting.instance.odds55.ToString();
		((TextBox)txtStake65).Text = Setting.instance.stake65.ToString();
		((TextBox)txtOdds65).Text = Setting.instance.odds65.ToString();
		((TextBox)txtStake75).Text = Setting.instance.stake75.ToString();
		((TextBox)txtOdds75).Text = Setting.instance.odds75.ToString();
		((TextBox)txtStake10m).Text = Setting.instance.stake10m.ToString();
		((TextBox)txtodds10m).Text = Setting.instance.odds10m.ToString();
		((TextBox)txtStake20m).Text = Setting.instance.stake20m.ToString();
		((TextBox)txtodds20m).Text = Setting.instance.odds20m.ToString();
		((TextBox)txtStake30m).Text = Setting.instance.stake30m.ToString();
		((TextBox)txtodds30m).Text = Setting.instance.odds30m.ToString();
		((TextBox)txtStake40m).Text = Setting.instance.stake40m.ToString();
		((TextBox)txtodds40m).Text = Setting.instance.odds40m.ToString();
		((TextBox)txtStake50m).Text = Setting.instance.stake50m.ToString();
		((TextBox)txtodds50m).Text = Setting.instance.odds50m.ToString();
		((TextBox)txtStake60m).Text = Setting.instance.stake60m.ToString();
		((TextBox)txtodds60m).Text = Setting.instance.odds60m.ToString();
		((TextBox)txtStake70m).Text = Setting.instance.stake70m.ToString();
		((TextBox)txtodds70m).Text = Setting.instance.odds70m.ToString();
		((TextBox)txtStake80m).Text = Setting.instance.stake80m.ToString();
		((TextBox)txtodds80m).Text = Setting.instance.odds80m.ToString();
		((TextBox)txtStake05HT).Text = Setting.instance.stake05HT.ToString();
		((TextBox)txtOdds05HT).Text = Setting.instance.odds05HT.ToString();
		((TextBox)txtStake15HT).Text = Setting.instance.stake15HT.ToString();
		((TextBox)txtOdds15HT).Text = Setting.instance.odds15HT.ToString();
		((TextBox)txtStake25HT).Text = Setting.instance.stake25HT.ToString();
		((TextBox)txtOdds25HT).Text = Setting.instance.odds25HT.ToString();
		((TextBox)txtStakeU25).Text = Setting.instance.stakeU25.ToString();
		((TextBox)txtOddsU25).Text = Setting.instance.oddsU25.ToString();
		((TextBox)txtStakeU35).Text = Setting.instance.stakeU35.ToString();
		((TextBox)txtOddsU35).Text = Setting.instance.oddsU35.ToString();
		((TextBox)txtStakeU45).Text = Setting.instance.stakeU45.ToString();
		((TextBox)txtOddsU45).Text = Setting.instance.oddsU45.ToString();
		((TextBox)txtStakehGoal).Text = Setting.instance.stakehGoal.ToString();
		((TextBox)txtOddshGoal).Text = Setting.instance.oddshGoal.ToString();
		((TextBox)txtStakeAGoal).Text = Setting.instance.stakeAGoal.ToString();
		((TextBox)txtOddsAGoal).Text = Setting.instance.oddsAGoal.ToString();
		((TextBox)txtStakeGoal).Text = Setting.instance.stakeGGoal.ToString();
		((TextBox)txtOddsGoal).Text = Setting.instance.oddsGGoal.ToString();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (canSave())
		{
			Setting.instance.stake05 = Utils.ParseToDouble(((TextBox)txtStake05).Text);
			Setting.instance.odds05 = Utils.ParseToDouble(((TextBox)txtOdds05).Text);
			Setting.instance.stake15 = Utils.ParseToDouble(((TextBox)txtStake15).Text);
			Setting.instance.odds15 = Utils.ParseToDouble(((TextBox)txtOdds15).Text);
			Setting.instance.stake25 = Utils.ParseToDouble(((TextBox)txtStake25).Text);
			Setting.instance.odds25 = Utils.ParseToDouble(((TextBox)txtOdds25).Text);
			Setting.instance.stake35 = Utils.ParseToDouble(((TextBox)txtStake35).Text);
			Setting.instance.odds35 = Utils.ParseToDouble(((TextBox)txtOdds35).Text);
			Setting.instance.stake45 = Utils.ParseToDouble(((TextBox)txtStake45).Text);
			Setting.instance.odds45 = Utils.ParseToDouble(((TextBox)txtOdds45).Text);
			Setting.instance.stake55 = Utils.ParseToDouble(((TextBox)txtStake55).Text);
			Setting.instance.odds55 = Utils.ParseToDouble(((TextBox)txtOdds55).Text);
			Setting.instance.stake65 = Utils.ParseToDouble(((TextBox)txtStake65).Text);
			Setting.instance.odds65 = Utils.ParseToDouble(((TextBox)txtOdds65).Text);
			Setting.instance.stake75 = Utils.ParseToDouble(((TextBox)txtStake75).Text);
			Setting.instance.odds75 = Utils.ParseToDouble(((TextBox)txtOdds75).Text);
			Setting.instance.stake10m = Utils.ParseToDouble(((TextBox)txtStake10m).Text);
			Setting.instance.odds10m = Utils.ParseToDouble(((TextBox)txtodds10m).Text);
			Setting.instance.stake20m = Utils.ParseToDouble(((TextBox)txtStake20m).Text);
			Setting.instance.odds20m = Utils.ParseToDouble(((TextBox)txtodds20m).Text);
			Setting.instance.stake30m = Utils.ParseToDouble(((TextBox)txtStake30m).Text);
			Setting.instance.odds30m = Utils.ParseToDouble(((TextBox)txtodds30m).Text);
			Setting.instance.stake40m = Utils.ParseToDouble(((TextBox)txtStake40m).Text);
			Setting.instance.odds40m = Utils.ParseToDouble(((TextBox)txtodds40m).Text);
			Setting.instance.stake50m = Utils.ParseToDouble(((TextBox)txtStake50m).Text);
			Setting.instance.odds50m = Utils.ParseToDouble(((TextBox)txtodds50m).Text);
			Setting.instance.stake60m = Utils.ParseToDouble(((TextBox)txtStake60m).Text);
			Setting.instance.odds60m = Utils.ParseToDouble(((TextBox)txtodds60m).Text);
			Setting.instance.stake70m = Utils.ParseToDouble(((TextBox)txtStake70m).Text);
			Setting.instance.odds70m = Utils.ParseToDouble(((TextBox)txtodds70m).Text);
			Setting.instance.stake80m = Utils.ParseToDouble(((TextBox)txtStake80m).Text);
			Setting.instance.odds80m = Utils.ParseToDouble(((TextBox)txtodds80m).Text);
			Setting.instance.stake05HT = Utils.ParseToDouble(((TextBox)txtStake05HT).Text);
			Setting.instance.odds05HT = Utils.ParseToDouble(((TextBox)txtOdds05HT).Text);
			Setting.instance.stake15HT = Utils.ParseToDouble(((TextBox)txtStake15HT).Text);
			Setting.instance.odds15HT = Utils.ParseToDouble(((TextBox)txtOdds15HT).Text);
			Setting.instance.stake25HT = Utils.ParseToDouble(((TextBox)txtStake25HT).Text);
			Setting.instance.odds25HT = Utils.ParseToDouble(((TextBox)txtOdds25HT).Text);
			Setting.instance.stakeU25 = Utils.ParseToDouble(((TextBox)txtStakeU25).Text);
			Setting.instance.oddsU25 = Utils.ParseToDouble(((TextBox)txtOddsU25).Text);
			Setting.instance.stakeU35 = Utils.ParseToDouble(((TextBox)txtStakeU35).Text);
			Setting.instance.oddsU35 = Utils.ParseToDouble(((TextBox)txtOddsU35).Text);
			Setting.instance.stakeU45 = Utils.ParseToDouble(((TextBox)txtStakeU45).Text);
			Setting.instance.oddsU45 = Utils.ParseToDouble(((TextBox)txtOddsU45).Text);
			Setting.instance.stakehGoal = Utils.ParseToDouble(((TextBox)txtStakehGoal).Text);
			Setting.instance.oddshGoal = Utils.ParseToDouble(((TextBox)txtOddshGoal).Text);
			Setting.instance.stakeAGoal = Utils.ParseToDouble(((TextBox)txtStakeAGoal).Text);
			Setting.instance.oddsAGoal = Utils.ParseToDouble(((TextBox)txtOddsAGoal).Text);
			Setting.instance.stakeGGoal = Utils.ParseToDouble(((TextBox)txtStakeGoal).Text);
			Setting.instance.oddsGGoal = Utils.ParseToDouble(((TextBox)txtOddsGoal).Text);
			((Form)this).DialogResult = (DialogResult)1;
		}
	}

	private bool canSave()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0629: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(((TextBox)txtStake05).Text))
		{
			MessageBox.Show("Please input Full Time Over 0.5 Stake!");
			((TextBox)txtStake05).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds05).Text))
		{
			MessageBox.Show("Please input Full Time Over 0.5 Min Odds!");
			((TextBox)txtOdds05).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake15).Text))
		{
			MessageBox.Show("Please input Full Time Over 1.5 Stake!");
			((TextBox)txtStake15).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds15).Text))
		{
			MessageBox.Show("Please input Full Time Over 1.5 Min Odds!");
			((TextBox)txtOdds15).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake25).Text))
		{
			MessageBox.Show("Please input Full Time Over 2.5 Stake!");
			((TextBox)txtStake25).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds35).Text))
		{
			MessageBox.Show("Please input Full Time Over 3.5 Min Odds!");
			((TextBox)txtOdds35).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake35).Text))
		{
			MessageBox.Show("Please input Full Time Over 3.5 Stake!");
			((TextBox)txtStake35).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds45).Text))
		{
			MessageBox.Show("Please input Full Time Over 4.5 Min Odds!");
			((TextBox)txtOdds45).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake45).Text))
		{
			MessageBox.Show("Please input Full Time Over 4.5 Stake!");
			((TextBox)txtStake45).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds55).Text))
		{
			MessageBox.Show("Please input Full Time Over 5.5 Min Odds!");
			((TextBox)txtOdds55).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake55).Text))
		{
			MessageBox.Show("Please input Full Time Over 5.5 Stake!");
			((TextBox)txtStake55).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds55).Text))
		{
			MessageBox.Show("Please input Full Time Over 5.5 Min Odds!");
			((TextBox)txtOdds55).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake65).Text))
		{
			MessageBox.Show("Please input Full Time Over 6.5 Stake!");
			((TextBox)txtStake65).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds65).Text))
		{
			MessageBox.Show("Please input Full Time Over 6.5 Min Odds!");
			((TextBox)txtOdds65).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake75).Text))
		{
			MessageBox.Show("Please input Full Time Over 7.5 Stake!");
			((TextBox)txtStake75).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds75).Text))
		{
			MessageBox.Show("Please input Full Time Over 7.5 Min Odds!");
			((TextBox)txtOdds75).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake10m).Text))
		{
			MessageBox.Show("Please input BEFORE 10MINS Stake!");
			((TextBox)txtStake10m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds10m).Text))
		{
			MessageBox.Show("Please input BEFORE 10MINS Odds!");
			((TextBox)txtodds10m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake20m).Text))
		{
			MessageBox.Show("Please input BEFORE 20MINS Stake!");
			((TextBox)txtStake20m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds20m).Text))
		{
			MessageBox.Show("Please input BEFORE 20MINS Odds!");
			((TextBox)txtodds20m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake30m).Text))
		{
			MessageBox.Show("Please input BEFORE 30MINS Stake!");
			((TextBox)txtStake30m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds30m).Text))
		{
			MessageBox.Show("Please input BEFORE 30MINS Odds!");
			((TextBox)txtodds30m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake40m).Text))
		{
			MessageBox.Show("Please input BEFORE 40MINS Stake!");
			((TextBox)txtStake40m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds40m).Text))
		{
			MessageBox.Show("Please input BEFORE 40MINS Odds!");
			((TextBox)txtodds10m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake50m).Text))
		{
			MessageBox.Show("Please input BEFORE 50MINS Stake!");
			((TextBox)txtStake50m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds50m).Text))
		{
			MessageBox.Show("Please input BEFORE 50MINS Odds!");
			((TextBox)txtodds50m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake60m).Text))
		{
			MessageBox.Show("Please input BEFORE 60MINS Stake!");
			((TextBox)txtStake60m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds60m).Text))
		{
			MessageBox.Show("Please input BEFORE 60MINS Odds!");
			((TextBox)txtodds60m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake70m).Text))
		{
			MessageBox.Show("Please input BEFORE 70MINS Stake!");
			((TextBox)txtStake70m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds70m).Text))
		{
			MessageBox.Show("Please input BEFORE 70MINS Odds!");
			((TextBox)txtodds70m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake80m).Text))
		{
			MessageBox.Show("Please input BEFORE 80MINS Stake!");
			((TextBox)txtStake80m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtodds80m).Text))
		{
			MessageBox.Show("Please input BEFORE 80MINS Odds!");
			((TextBox)txtodds80m).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake05HT).Text))
		{
			MessageBox.Show("Please input OVER 0.5 Half Time Stake!");
			((TextBox)txtStake05HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds05HT).Text))
		{
			MessageBox.Show("Please input OVER 0.5 Half Time Odds!");
			((TextBox)txtOdds05HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake15HT).Text))
		{
			MessageBox.Show("Please input OVER 1.5 Half Time Stake!");
			((TextBox)txtStake15HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds15HT).Text))
		{
			MessageBox.Show("Please input OVER 1.5 Half Time Odds!");
			((TextBox)txtOdds15HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStake25HT).Text))
		{
			MessageBox.Show("Please input OVER 2.5 Half Time Stake!");
			((TextBox)txtStake25HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOdds25HT).Text))
		{
			MessageBox.Show("Please input OVER 2.5 Half Time Odds!");
			((TextBox)txtOdds25HT).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakeU25).Text))
		{
			MessageBox.Show("Please input Under 2.5 Full Time Stake!");
			((TextBox)txtStakeU25).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddsU25).Text))
		{
			MessageBox.Show("Please input Under 2.5 Full Time Odds!");
			((TextBox)txtOddsU25).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakeU35).Text))
		{
			MessageBox.Show("Please input Under 3.5 Full Time Stake!");
			((TextBox)txtStakeU35).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddsU35).Text))
		{
			MessageBox.Show("Please input Under 3.5 Full Time Odds!");
			((TextBox)txtOddsU35).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakeU45).Text))
		{
			MessageBox.Show("Please input Under 4.5 Full Time Stake!");
			((TextBox)txtStakeU45).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddsU45).Text))
		{
			MessageBox.Show("Please input Under 4.5 Full Time Odds!");
			((TextBox)txtOddsU45).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakehGoal).Text))
		{
			MessageBox.Show("Please input NEXT GOAL HOME TEAM Stake!");
			((TextBox)txtStakehGoal).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddshGoal).Text))
		{
			MessageBox.Show("Please input NEXT GOAL HOME TEAM Odds!");
			((TextBox)txtOddshGoal).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakeAGoal).Text))
		{
			MessageBox.Show("Please input NEXT GOAL AWAY TEAM Stake!");
			((TextBox)txtStakeAGoal).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddsAGoal).Text))
		{
			MessageBox.Show("Please input NEXT GOAL AWAY TEAM Odds!");
			((TextBox)txtOddsAGoal).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtStakeGoal).Text))
		{
			MessageBox.Show("Please input GOAL GOLA Stake!");
			((TextBox)txtStakeGoal).Focus();
			return false;
		}
		if (string.IsNullOrEmpty(((TextBox)txtOddsGoal).Text))
		{
			MessageBox.Show("Please input GOAL GOLA Odds!");
			((TextBox)txtOddsGoal).Focus();
			return false;
		}
		return true;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
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
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_0a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Expected O, but got Unknown
		//IL_0c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Expected O, but got Unknown
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1346: Unknown result type (might be due to invalid IL or missing references)
		//IL_1350: Expected O, but got Unknown
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1716: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c0: Expected O, but got Unknown
		//IL_199a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2a: Expected O, but got Unknown
		//IL_1dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2084: Unknown result type (might be due to invalid IL or missing references)
		//IL_208e: Expected O, but got Unknown
		//IL_2119: Unknown result type (might be due to invalid IL or missing references)
		//IL_2123: Expected O, but got Unknown
		//IL_22f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_24dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_257d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2587: Expected O, but got Unknown
		//IL_2755: Unknown result type (might be due to invalid IL or missing references)
		//IL_2936: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_2da3: Expected O, but got Unknown
		//IL_2f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f33: Expected O, but got Unknown
		//IL_2fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fda: Expected O, but got Unknown
		//IL_3064: Unknown result type (might be due to invalid IL or missing references)
		//IL_306e: Expected O, but got Unknown
		//IL_323e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3424: Unknown result type (might be due to invalid IL or missing references)
		//IL_360a: Unknown result type (might be due to invalid IL or missing references)
		//IL_37eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_39cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c58: Expected O, but got Unknown
		//IL_3f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f31: Expected O, but got Unknown
		//IL_4123: Unknown result type (might be due to invalid IL or missing references)
		//IL_4318: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_43c2: Expected O, but got Unknown
		//IL_45a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4791: Unknown result type (might be due to invalid IL or missing references)
		//IL_4831: Unknown result type (might be due to invalid IL or missing references)
		//IL_483b: Expected O, but got Unknown
		//IL_4a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cae: Expected O, but got Unknown
		//IL_4e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_5071: Unknown result type (might be due to invalid IL or missing references)
		//IL_5111: Unknown result type (might be due to invalid IL or missing references)
		//IL_511b: Expected O, but got Unknown
		//IL_52ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_54d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5578: Unknown result type (might be due to invalid IL or missing references)
		//IL_5582: Expected O, but got Unknown
		//IL_560d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5617: Expected O, but got Unknown
		//IL_57eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_59d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a7e: Expected O, but got Unknown
		//IL_5c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_6014: Unknown result type (might be due to invalid IL or missing references)
		//IL_61f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_6296: Unknown result type (might be due to invalid IL or missing references)
		//IL_62a0: Expected O, but got Unknown
		//IL_6426: Unknown result type (might be due to invalid IL or missing references)
		//IL_6430: Expected O, but got Unknown
		//IL_64d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_64da: Expected O, but got Unknown
		//IL_6565: Unknown result type (might be due to invalid IL or missing references)
		//IL_656f: Expected O, but got Unknown
		//IL_6740: Unknown result type (might be due to invalid IL or missing references)
		//IL_6929: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_70b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_7159: Unknown result type (might be due to invalid IL or missing references)
		//IL_7163: Expected O, but got Unknown
		//IL_72e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_72f3: Expected O, but got Unknown
		//IL_7390: Unknown result type (might be due to invalid IL or missing references)
		//IL_739a: Expected O, but got Unknown
		//IL_7425: Unknown result type (might be due to invalid IL or missing references)
		//IL_742f: Expected O, but got Unknown
		//IL_7603: Unknown result type (might be due to invalid IL or missing references)
		//IL_77ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_79d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_801c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8026: Expected O, but got Unknown
		//IL_812b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8135: Expected O, but got Unknown
		//IL_824c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8256: Expected O, but got Unknown
		DragPanel = new SiticonePanel();
		siticonePictureBox2 = new SiticonePictureBox();
		siticoneHtmlLabel12 = new SiticoneHtmlLabel();
		siticoneControlBox2 = new SiticoneControlBox();
		siticoneControlBox1 = new SiticoneControlBox();
		siticoneGroupBox1 = new SiticoneGroupBox();
		txtOdds75 = new SiticoneTextBox();
		txtStake75 = new SiticoneTextBox();
		siticoneHtmlLabel8 = new SiticoneHtmlLabel();
		txtOdds65 = new SiticoneTextBox();
		txtStake65 = new SiticoneTextBox();
		siticoneHtmlLabel7 = new SiticoneHtmlLabel();
		txtOdds55 = new SiticoneTextBox();
		txtStake55 = new SiticoneTextBox();
		siticoneHtmlLabel6 = new SiticoneHtmlLabel();
		txtOdds45 = new SiticoneTextBox();
		txtStake45 = new SiticoneTextBox();
		siticoneHtmlLabel5 = new SiticoneHtmlLabel();
		txtOdds35 = new SiticoneTextBox();
		txtStake35 = new SiticoneTextBox();
		siticoneHtmlLabel4 = new SiticoneHtmlLabel();
		siticoneHtmlLabel2 = new SiticoneHtmlLabel();
		txtOdds25 = new SiticoneTextBox();
		txtStake25 = new SiticoneTextBox();
		siticoneHtmlLabel1 = new SiticoneHtmlLabel();
		txtOdds15 = new SiticoneTextBox();
		txtStake15 = new SiticoneTextBox();
		txtOdds05 = new SiticoneTextBox();
		txtStake05 = new SiticoneTextBox();
		siticoneHtmlLabel3 = new SiticoneHtmlLabel();
		siticoneGroupBox2 = new SiticoneGroupBox();
		siticoneHtmlLabel15 = new SiticoneHtmlLabel();
		siticoneHtmlLabel16 = new SiticoneHtmlLabel();
		txtOdds25HT = new SiticoneTextBox();
		txtStake25HT = new SiticoneTextBox();
		txtOdds15HT = new SiticoneTextBox();
		txtStake15HT = new SiticoneTextBox();
		txtOdds05HT = new SiticoneTextBox();
		txtStake05HT = new SiticoneTextBox();
		siticoneHtmlLabel17 = new SiticoneHtmlLabel();
		siticoneGroupBox3 = new SiticoneGroupBox();
		txtodds80m = new SiticoneTextBox();
		txtStake80m = new SiticoneTextBox();
		siticoneHtmlLabel9 = new SiticoneHtmlLabel();
		txtodds70m = new SiticoneTextBox();
		txtStake70m = new SiticoneTextBox();
		siticoneHtmlLabel10 = new SiticoneHtmlLabel();
		txtodds60m = new SiticoneTextBox();
		txtStake60m = new SiticoneTextBox();
		siticoneHtmlLabel11 = new SiticoneHtmlLabel();
		txtodds50m = new SiticoneTextBox();
		txtStake50m = new SiticoneTextBox();
		siticoneHtmlLabel13 = new SiticoneHtmlLabel();
		txtodds40m = new SiticoneTextBox();
		txtStake40m = new SiticoneTextBox();
		siticoneHtmlLabel14 = new SiticoneHtmlLabel();
		siticoneHtmlLabel18 = new SiticoneHtmlLabel();
		txtodds30m = new SiticoneTextBox();
		txtStake30m = new SiticoneTextBox();
		siticoneHtmlLabel19 = new SiticoneHtmlLabel();
		txtodds20m = new SiticoneTextBox();
		txtStake20m = new SiticoneTextBox();
		txtodds10m = new SiticoneTextBox();
		txtStake10m = new SiticoneTextBox();
		siticoneHtmlLabel20 = new SiticoneHtmlLabel();
		siticoneGroupBox4 = new SiticoneGroupBox();
		siticoneHtmlLabel22 = new SiticoneHtmlLabel();
		siticoneHtmlLabel21 = new SiticoneHtmlLabel();
		txtOddsU45 = new SiticoneTextBox();
		txtStakeU45 = new SiticoneTextBox();
		txtOddsU35 = new SiticoneTextBox();
		txtStakeU35 = new SiticoneTextBox();
		txtOddsU25 = new SiticoneTextBox();
		txtStakeU25 = new SiticoneTextBox();
		siticoneHtmlLabel23 = new SiticoneHtmlLabel();
		siticoneGroupBox5 = new SiticoneGroupBox();
		siticoneHtmlLabel24 = new SiticoneHtmlLabel();
		siticoneHtmlLabel25 = new SiticoneHtmlLabel();
		txtOddsGoal = new SiticoneTextBox();
		txtStakeGoal = new SiticoneTextBox();
		txtOddsAGoal = new SiticoneTextBox();
		txtStakeAGoal = new SiticoneTextBox();
		txtOddshGoal = new SiticoneTextBox();
		txtStakehGoal = new SiticoneTextBox();
		siticoneHtmlLabel26 = new SiticoneHtmlLabel();
		btnCancel = new SiticoneButton();
		btnSave = new SiticoneButton();
		((Control)DragPanel).SuspendLayout();
		((ISupportInitialize)siticonePictureBox2).BeginInit();
		((Control)siticoneGroupBox1).SuspendLayout();
		((Control)siticoneGroupBox2).SuspendLayout();
		((Control)siticoneGroupBox3).SuspendLayout();
		((Control)siticoneGroupBox4).SuspendLayout();
		((Control)siticoneGroupBox5).SuspendLayout();
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
		((Control)DragPanel).Size = new Size(1255, 50);
		((Control)DragPanel).TabIndex = 53;
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
		((Control)siticoneControlBox2).Location = new Point(1154, 2);
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
		((Control)siticoneControlBox1).Location = new Point(1203, 2);
		((Control)siticoneControlBox1).Name = "siticoneControlBox1";
		siticoneControlBox1.PressedColor = Color.White;
		((Control)siticoneControlBox1).Size = new Size(49, 45);
		((Control)siticoneControlBox1).TabIndex = 0;
		((Control)siticoneGroupBox1).BackColor = Color.Transparent;
		siticoneGroupBox1.BorderThickness = 0;
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds75);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake75);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel8);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds65);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake65);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel7);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds55);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake55);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel6);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds45);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake45);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel5);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds35);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake35);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel4);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel2);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds25);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake25);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel1);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds15);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake15);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtOdds05);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)txtStake05);
		((Control)siticoneGroupBox1).Controls.Add((Control)(object)siticoneHtmlLabel3);
		siticoneGroupBox1.CustomBorderColor = Color.FromArgb(60, 62, 118);
		siticoneGroupBox1.FillColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGroupBox1).Font = new Font("Bahnschrift SemiCondensed", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneGroupBox1).ForeColor = Color.Salmon;
		((Control)siticoneGroupBox1).Location = new Point(35, 65);
		((Control)siticoneGroupBox1).Name = "siticoneGroupBox1";
		((Control)siticoneGroupBox1).Size = new Size(343, 383);
		((Control)siticoneGroupBox1).TabIndex = 54;
		((Control)siticoneGroupBox1).Text = "OVER OR GOAL SUCCESSIVE FULL TIME";
		siticoneGroupBox1.TextAlign = (HorizontalAlignment)2;
		((Control)txtOdds75).Cursor = Cursors.IBeam;
		((TextBox)txtOdds75).DefaultText = "1.5";
		txtOdds75.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds75.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds75.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds75.DisabledState.Parent = (TextBox)(object)txtOdds75;
		txtOdds75.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds75.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds75.FocusedState.Parent = (TextBox)(object)txtOdds75;
		((TextBox)txtOdds75).ForeColor = Color.Black;
		txtOdds75.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds75.HoveredState.Parent = (TextBox)(object)txtOdds75;
		((Control)txtOdds75).Location = new Point(218, 338);
		((Control)txtOdds75).Margin = new Padding(287, 1158, 287, 1158);
		((Control)txtOdds75).Name = "txtOdds75";
		((TextBox)txtOdds75).PasswordChar = '\0';
		txtOdds75.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds75).SelectedText = "";
		txtOdds75.ShadowDecoration.Parent = (Control)(object)txtOdds75;
		((Control)txtOdds75).Size = new Size(102, 29);
		((Control)txtOdds75).TabIndex = 67;
		((Control)txtStake75).Cursor = Cursors.IBeam;
		((TextBox)txtStake75).DefaultText = "5";
		txtStake75.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake75.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake75.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake75.DisabledState.Parent = (TextBox)(object)txtStake75;
		txtStake75.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake75.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake75.FocusedState.Parent = (TextBox)(object)txtStake75;
		((TextBox)txtStake75).ForeColor = Color.Black;
		txtStake75.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake75.HoveredState.Parent = (TextBox)(object)txtStake75;
		((Control)txtStake75).Location = new Point(111, 338);
		((Control)txtStake75).Margin = new Padding(172, 602, 172, 602);
		((Control)txtStake75).Name = "txtStake75";
		((TextBox)txtStake75).PasswordChar = '\0';
		txtStake75.PlaceholderText = "STAKE";
		((TextBox)txtStake75).SelectedText = "";
		txtStake75.ShadowDecoration.Parent = (Control)(object)txtStake75;
		((Control)txtStake75).Size = new Size(93, 29);
		((Control)txtStake75).TabIndex = 66;
		((Control)siticoneHtmlLabel8).BackColor = Color.Transparent;
		siticoneHtmlLabel8.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel8.ForeColor = Color.White;
		((Control)siticoneHtmlLabel8).Location = new Point(27, 341);
		((Control)siticoneHtmlLabel8).Name = "siticoneHtmlLabel8";
		((Control)siticoneHtmlLabel8).Size = new Size(66, 21);
		((Control)siticoneHtmlLabel8).TabIndex = 65;
		((Control)siticoneHtmlLabel8).Text = "OVER 7.5 : ";
		((Control)txtOdds65).Cursor = Cursors.IBeam;
		((TextBox)txtOdds65).DefaultText = "1.5";
		txtOdds65.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds65.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds65.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds65.DisabledState.Parent = (TextBox)(object)txtOdds65;
		txtOdds65.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds65.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds65.FocusedState.Parent = (TextBox)(object)txtOdds65;
		((TextBox)txtOdds65).ForeColor = Color.Black;
		txtOdds65.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds65.HoveredState.Parent = (TextBox)(object)txtOdds65;
		((Control)txtOdds65).Location = new Point(218, 298);
		((Control)txtOdds65).Margin = new Padding(172, 602, 172, 602);
		((Control)txtOdds65).Name = "txtOdds65";
		((TextBox)txtOdds65).PasswordChar = '\0';
		txtOdds65.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds65).SelectedText = "";
		txtOdds65.ShadowDecoration.Parent = (Control)(object)txtOdds65;
		((Control)txtOdds65).Size = new Size(102, 29);
		((Control)txtOdds65).TabIndex = 64;
		((Control)txtStake65).Cursor = Cursors.IBeam;
		((TextBox)txtStake65).DefaultText = "5";
		txtStake65.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake65.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake65.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake65.DisabledState.Parent = (TextBox)(object)txtStake65;
		txtStake65.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake65.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake65.FocusedState.Parent = (TextBox)(object)txtStake65;
		((TextBox)txtStake65).ForeColor = Color.Black;
		txtStake65.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake65.HoveredState.Parent = (TextBox)(object)txtStake65;
		((Control)txtStake65).Location = new Point(111, 298);
		((Control)txtStake65).Margin = new Padding(103, 313, 103, 313);
		((Control)txtStake65).Name = "txtStake65";
		((TextBox)txtStake65).PasswordChar = '\0';
		txtStake65.PlaceholderText = "STAKE";
		((TextBox)txtStake65).SelectedText = "";
		txtStake65.ShadowDecoration.Parent = (Control)(object)txtStake65;
		((Control)txtStake65).Size = new Size(93, 29);
		((Control)txtStake65).TabIndex = 63;
		((Control)siticoneHtmlLabel7).BackColor = Color.Transparent;
		siticoneHtmlLabel7.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel7.ForeColor = Color.White;
		((Control)siticoneHtmlLabel7).Location = new Point(26, 302);
		((Control)siticoneHtmlLabel7).Name = "siticoneHtmlLabel7";
		((Control)siticoneHtmlLabel7).Size = new Size(66, 21);
		((Control)siticoneHtmlLabel7).TabIndex = 62;
		((Control)siticoneHtmlLabel7).Text = "OVER 6.5 : ";
		((Control)txtOdds55).Cursor = Cursors.IBeam;
		((TextBox)txtOdds55).DefaultText = "1.5";
		txtOdds55.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds55.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds55.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds55.DisabledState.Parent = (TextBox)(object)txtOdds55;
		txtOdds55.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds55.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds55.FocusedState.Parent = (TextBox)(object)txtOdds55;
		((TextBox)txtOdds55).ForeColor = Color.Black;
		txtOdds55.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds55.HoveredState.Parent = (TextBox)(object)txtOdds55;
		((Control)txtOdds55).Location = new Point(218, 258);
		((Control)txtOdds55).Margin = new Padding(103, 313, 103, 313);
		((Control)txtOdds55).Name = "txtOdds55";
		((TextBox)txtOdds55).PasswordChar = '\0';
		txtOdds55.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds55).SelectedText = "";
		txtOdds55.ShadowDecoration.Parent = (Control)(object)txtOdds55;
		((Control)txtOdds55).Size = new Size(102, 29);
		((Control)txtOdds55).TabIndex = 61;
		((Control)txtStake55).Cursor = Cursors.IBeam;
		((TextBox)txtStake55).DefaultText = "5";
		txtStake55.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake55.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake55.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake55.DisabledState.Parent = (TextBox)(object)txtStake55;
		txtStake55.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake55.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake55.FocusedState.Parent = (TextBox)(object)txtStake55;
		((TextBox)txtStake55).ForeColor = Color.Black;
		txtStake55.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake55.HoveredState.Parent = (TextBox)(object)txtStake55;
		((Control)txtStake55).Location = new Point(111, 258);
		((Control)txtStake55).Margin = new Padding(62, 163, 62, 163);
		((Control)txtStake55).Name = "txtStake55";
		((TextBox)txtStake55).PasswordChar = '\0';
		txtStake55.PlaceholderText = "STAKE";
		((TextBox)txtStake55).SelectedText = "";
		txtStake55.ShadowDecoration.Parent = (Control)(object)txtStake55;
		((Control)txtStake55).Size = new Size(93, 29);
		((Control)txtStake55).TabIndex = 60;
		((Control)siticoneHtmlLabel6).BackColor = Color.Transparent;
		siticoneHtmlLabel6.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel6.ForeColor = Color.White;
		((Control)siticoneHtmlLabel6).Location = new Point(27, 262);
		((Control)siticoneHtmlLabel6).Name = "siticoneHtmlLabel6";
		((Control)siticoneHtmlLabel6).Size = new Size(67, 21);
		((Control)siticoneHtmlLabel6).TabIndex = 59;
		((Control)siticoneHtmlLabel6).Text = "OVER 5.5 : ";
		((Control)txtOdds45).Cursor = Cursors.IBeam;
		((TextBox)txtOdds45).DefaultText = "1.5";
		txtOdds45.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds45.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds45.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds45.DisabledState.Parent = (TextBox)(object)txtOdds45;
		txtOdds45.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds45.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds45.FocusedState.Parent = (TextBox)(object)txtOdds45;
		((TextBox)txtOdds45).ForeColor = Color.Black;
		txtOdds45.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds45.HoveredState.Parent = (TextBox)(object)txtOdds45;
		((Control)txtOdds45).Location = new Point(218, 218);
		((Control)txtOdds45).Margin = new Padding(62, 163, 62, 163);
		((Control)txtOdds45).Name = "txtOdds45";
		((TextBox)txtOdds45).PasswordChar = '\0';
		txtOdds45.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds45).SelectedText = "";
		txtOdds45.ShadowDecoration.Parent = (Control)(object)txtOdds45;
		((Control)txtOdds45).Size = new Size(102, 29);
		((Control)txtOdds45).TabIndex = 58;
		((Control)txtStake45).Cursor = Cursors.IBeam;
		((TextBox)txtStake45).DefaultText = "5";
		txtStake45.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake45.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake45.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake45.DisabledState.Parent = (TextBox)(object)txtStake45;
		txtStake45.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake45.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake45.FocusedState.Parent = (TextBox)(object)txtStake45;
		((TextBox)txtStake45).ForeColor = Color.Black;
		txtStake45.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake45.HoveredState.Parent = (TextBox)(object)txtStake45;
		((Control)txtStake45).Location = new Point(111, 218);
		((Control)txtStake45).Margin = new Padding(37, 85, 37, 85);
		((Control)txtStake45).Name = "txtStake45";
		((TextBox)txtStake45).PasswordChar = '\0';
		txtStake45.PlaceholderText = "STAKE";
		((TextBox)txtStake45).SelectedText = "";
		txtStake45.ShadowDecoration.Parent = (Control)(object)txtStake45;
		((Control)txtStake45).Size = new Size(93, 29);
		((Control)txtStake45).TabIndex = 57;
		((Control)siticoneHtmlLabel5).BackColor = Color.Transparent;
		siticoneHtmlLabel5.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel5.ForeColor = Color.White;
		((Control)siticoneHtmlLabel5).Location = new Point(27, 222);
		((Control)siticoneHtmlLabel5).Name = "siticoneHtmlLabel5";
		((Control)siticoneHtmlLabel5).Size = new Size(67, 21);
		((Control)siticoneHtmlLabel5).TabIndex = 56;
		((Control)siticoneHtmlLabel5).Text = "OVER 4.5 : ";
		((Control)txtOdds35).Cursor = Cursors.IBeam;
		((TextBox)txtOdds35).DefaultText = "1.5";
		txtOdds35.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds35.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds35.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds35.DisabledState.Parent = (TextBox)(object)txtOdds35;
		txtOdds35.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds35.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds35.FocusedState.Parent = (TextBox)(object)txtOdds35;
		((TextBox)txtOdds35).ForeColor = Color.Black;
		txtOdds35.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds35.HoveredState.Parent = (TextBox)(object)txtOdds35;
		((Control)txtOdds35).Location = new Point(218, 179);
		((Control)txtOdds35).Margin = new Padding(37, 85, 37, 85);
		((Control)txtOdds35).Name = "txtOdds35";
		((TextBox)txtOdds35).PasswordChar = '\0';
		txtOdds35.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds35).SelectedText = "";
		txtOdds35.ShadowDecoration.Parent = (Control)(object)txtOdds35;
		((Control)txtOdds35).Size = new Size(102, 29);
		((Control)txtOdds35).TabIndex = 55;
		((Control)txtStake35).Cursor = Cursors.IBeam;
		((TextBox)txtStake35).DefaultText = "5";
		txtStake35.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake35.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake35.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake35.DisabledState.Parent = (TextBox)(object)txtStake35;
		txtStake35.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake35.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake35.FocusedState.Parent = (TextBox)(object)txtStake35;
		((TextBox)txtStake35).ForeColor = Color.Black;
		txtStake35.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake35.HoveredState.Parent = (TextBox)(object)txtStake35;
		((Control)txtStake35).Location = new Point(111, 179);
		((Control)txtStake35).Margin = new Padding(22, 44, 22, 44);
		((Control)txtStake35).Name = "txtStake35";
		((TextBox)txtStake35).PasswordChar = '\0';
		txtStake35.PlaceholderText = "STAKE";
		((TextBox)txtStake35).SelectedText = "";
		txtStake35.ShadowDecoration.Parent = (Control)(object)txtStake35;
		((Control)txtStake35).Size = new Size(93, 29);
		((Control)txtStake35).TabIndex = 54;
		((Control)siticoneHtmlLabel4).BackColor = Color.Transparent;
		siticoneHtmlLabel4.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel4.ForeColor = Color.White;
		((Control)siticoneHtmlLabel4).Location = new Point(27, 184);
		((Control)siticoneHtmlLabel4).Name = "siticoneHtmlLabel4";
		((Control)siticoneHtmlLabel4).Size = new Size(66, 21);
		((Control)siticoneHtmlLabel4).TabIndex = 53;
		((Control)siticoneHtmlLabel4).Text = "OVER 3.5 : ";
		((Control)siticoneHtmlLabel2).BackColor = Color.Transparent;
		siticoneHtmlLabel2.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel2.ForeColor = Color.White;
		((Control)siticoneHtmlLabel2).Location = new Point(27, 143);
		((Control)siticoneHtmlLabel2).Name = "siticoneHtmlLabel2";
		((Control)siticoneHtmlLabel2).Size = new Size(66, 21);
		((Control)siticoneHtmlLabel2).TabIndex = 52;
		((Control)siticoneHtmlLabel2).Text = "OVER 2.5 : ";
		((Control)txtOdds25).Cursor = Cursors.IBeam;
		((TextBox)txtOdds25).DefaultText = "1.5";
		txtOdds25.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds25.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds25.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds25.DisabledState.Parent = (TextBox)(object)txtOdds25;
		txtOdds25.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds25.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds25.FocusedState.Parent = (TextBox)(object)txtOdds25;
		((TextBox)txtOdds25).ForeColor = Color.Black;
		txtOdds25.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds25.HoveredState.Parent = (TextBox)(object)txtOdds25;
		((Control)txtOdds25).Location = new Point(218, 138);
		((Control)txtOdds25).Margin = new Padding(22, 44, 22, 44);
		((Control)txtOdds25).Name = "txtOdds25";
		((TextBox)txtOdds25).PasswordChar = '\0';
		txtOdds25.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds25).SelectedText = "";
		txtOdds25.ShadowDecoration.Parent = (Control)(object)txtOdds25;
		((Control)txtOdds25).Size = new Size(102, 29);
		((Control)txtOdds25).TabIndex = 51;
		((Control)txtStake25).Cursor = Cursors.IBeam;
		((TextBox)txtStake25).DefaultText = "5";
		txtStake25.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake25.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake25.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake25.DisabledState.Parent = (TextBox)(object)txtStake25;
		txtStake25.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake25.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake25.FocusedState.Parent = (TextBox)(object)txtStake25;
		((TextBox)txtStake25).ForeColor = Color.Black;
		txtStake25.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake25.HoveredState.Parent = (TextBox)(object)txtStake25;
		((Control)txtStake25).Location = new Point(111, 138);
		((Control)txtStake25).Margin = new Padding(13, 23, 13, 23);
		((Control)txtStake25).Name = "txtStake25";
		((TextBox)txtStake25).PasswordChar = '\0';
		txtStake25.PlaceholderText = "STAKE";
		((TextBox)txtStake25).SelectedText = "";
		txtStake25.ShadowDecoration.Parent = (Control)(object)txtStake25;
		((Control)txtStake25).Size = new Size(93, 29);
		((Control)txtStake25).TabIndex = 50;
		((Control)siticoneHtmlLabel1).BackColor = Color.Transparent;
		siticoneHtmlLabel1.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel1.ForeColor = Color.White;
		((Control)siticoneHtmlLabel1).Location = new Point(26, 101);
		((Control)siticoneHtmlLabel1).Name = "siticoneHtmlLabel1";
		((Control)siticoneHtmlLabel1).Size = new Size(64, 21);
		((Control)siticoneHtmlLabel1).TabIndex = 49;
		((Control)siticoneHtmlLabel1).Text = "OVER 1.5 : ";
		((Control)txtOdds15).Cursor = Cursors.IBeam;
		((TextBox)txtOdds15).DefaultText = "1.5";
		txtOdds15.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds15.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds15.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds15.DisabledState.Parent = (TextBox)(object)txtOdds15;
		txtOdds15.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds15.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds15.FocusedState.Parent = (TextBox)(object)txtOdds15;
		((TextBox)txtOdds15).ForeColor = Color.Black;
		txtOdds15.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds15.HoveredState.Parent = (TextBox)(object)txtOdds15;
		((Control)txtOdds15).Location = new Point(218, 97);
		((Control)txtOdds15).Margin = new Padding(13, 23, 13, 23);
		((Control)txtOdds15).Name = "txtOdds15";
		((TextBox)txtOdds15).PasswordChar = '\0';
		txtOdds15.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds15).SelectedText = "";
		txtOdds15.ShadowDecoration.Parent = (Control)(object)txtOdds15;
		((Control)txtOdds15).Size = new Size(102, 29);
		((Control)txtOdds15).TabIndex = 48;
		((Control)txtStake15).Cursor = Cursors.IBeam;
		((TextBox)txtStake15).DefaultText = "5";
		txtStake15.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake15.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake15.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake15.DisabledState.Parent = (TextBox)(object)txtStake15;
		txtStake15.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake15.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake15.FocusedState.Parent = (TextBox)(object)txtStake15;
		((TextBox)txtStake15).ForeColor = Color.Black;
		txtStake15.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake15.HoveredState.Parent = (TextBox)(object)txtStake15;
		((Control)txtStake15).Location = new Point(111, 97);
		((Control)txtStake15).Margin = new Padding(8, 12, 8, 12);
		((Control)txtStake15).Name = "txtStake15";
		((TextBox)txtStake15).PasswordChar = '\0';
		txtStake15.PlaceholderText = "STAKE";
		((TextBox)txtStake15).SelectedText = "";
		txtStake15.ShadowDecoration.Parent = (Control)(object)txtStake15;
		((Control)txtStake15).Size = new Size(93, 29);
		((Control)txtStake15).TabIndex = 47;
		((Control)txtOdds05).Cursor = Cursors.IBeam;
		((TextBox)txtOdds05).DefaultText = "1.5";
		txtOdds05.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds05.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds05.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds05.DisabledState.Parent = (TextBox)(object)txtOdds05;
		txtOdds05.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds05.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds05.FocusedState.Parent = (TextBox)(object)txtOdds05;
		((TextBox)txtOdds05).ForeColor = Color.Black;
		txtOdds05.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds05.HoveredState.Parent = (TextBox)(object)txtOdds05;
		((Control)txtOdds05).Location = new Point(218, 57);
		((Control)txtOdds05).Margin = new Padding(8, 12, 8, 12);
		((Control)txtOdds05).Name = "txtOdds05";
		((TextBox)txtOdds05).PasswordChar = '\0';
		txtOdds05.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds05).SelectedText = "";
		txtOdds05.ShadowDecoration.Parent = (Control)(object)txtOdds05;
		((Control)txtOdds05).Size = new Size(102, 29);
		((Control)txtOdds05).TabIndex = 46;
		((Control)txtStake05).Cursor = Cursors.IBeam;
		((TextBox)txtStake05).DefaultText = "5";
		txtStake05.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake05.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake05.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake05.DisabledState.Parent = (TextBox)(object)txtStake05;
		txtStake05.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake05.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake05.FocusedState.Parent = (TextBox)(object)txtStake05;
		((TextBox)txtStake05).ForeColor = Color.Black;
		txtStake05.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake05.HoveredState.Parent = (TextBox)(object)txtStake05;
		((Control)txtStake05).Location = new Point(111, 57);
		((Control)txtStake05).Margin = new Padding(5, 6, 5, 6);
		((Control)txtStake05).Name = "txtStake05";
		((TextBox)txtStake05).PasswordChar = '\0';
		txtStake05.PlaceholderText = "STAKE";
		((TextBox)txtStake05).SelectedText = "";
		txtStake05.ShadowDecoration.Parent = (Control)(object)txtStake05;
		((Control)txtStake05).Size = new Size(93, 29);
		((Control)txtStake05).TabIndex = 45;
		((Control)siticoneHtmlLabel3).BackColor = Color.Transparent;
		siticoneHtmlLabel3.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel3.ForeColor = Color.White;
		((Control)siticoneHtmlLabel3).Location = new Point(26, 60);
		((Control)siticoneHtmlLabel3).Name = "siticoneHtmlLabel3";
		((Control)siticoneHtmlLabel3).Size = new Size(67, 21);
		((Control)siticoneHtmlLabel3).TabIndex = 44;
		((Control)siticoneHtmlLabel3).Text = "OVER 0.5 : ";
		((Control)siticoneGroupBox2).BackColor = Color.Transparent;
		siticoneGroupBox2.BorderThickness = 0;
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)siticoneHtmlLabel15);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)siticoneHtmlLabel16);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtOdds25HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtStake25HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtOdds15HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtStake15HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtOdds05HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)txtStake05HT);
		((Control)siticoneGroupBox2).Controls.Add((Control)(object)siticoneHtmlLabel17);
		siticoneGroupBox2.CustomBorderColor = Color.FromArgb(60, 62, 118);
		siticoneGroupBox2.FillColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGroupBox2).Font = new Font("Bahnschrift SemiCondensed", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneGroupBox2).ForeColor = Color.Salmon;
		((Control)siticoneGroupBox2).Location = new Point(35, 466);
		((Control)siticoneGroupBox2).Name = "siticoneGroupBox2";
		((Control)siticoneGroupBox2).Size = new Size(343, 221);
		((Control)siticoneGroupBox2).TabIndex = 55;
		((Control)siticoneGroupBox2).Text = "OVER HALF TIME";
		siticoneGroupBox2.TextAlign = (HorizontalAlignment)2;
		((Control)siticoneHtmlLabel15).BackColor = Color.Transparent;
		siticoneHtmlLabel15.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel15.ForeColor = Color.White;
		((Control)siticoneHtmlLabel15).Location = new Point(7, 157);
		((Control)siticoneHtmlLabel15).Name = "siticoneHtmlLabel15";
		((Control)siticoneHtmlLabel15).Size = new Size(86, 21);
		((Control)siticoneHtmlLabel15).TabIndex = 69;
		((Control)siticoneHtmlLabel15).Text = "OVER 2.5 HT : ";
		((Control)siticoneHtmlLabel16).BackColor = Color.Transparent;
		siticoneHtmlLabel16.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel16.ForeColor = Color.White;
		((Control)siticoneHtmlLabel16).Location = new Point(7, 115);
		((Control)siticoneHtmlLabel16).Name = "siticoneHtmlLabel16";
		((Control)siticoneHtmlLabel16).Size = new Size(84, 21);
		((Control)siticoneHtmlLabel16).TabIndex = 68;
		((Control)siticoneHtmlLabel16).Text = "OVER 1.5 HT : ";
		((Control)txtOdds25HT).Cursor = Cursors.IBeam;
		((TextBox)txtOdds25HT).DefaultText = "1.5";
		txtOdds25HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds25HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds25HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds25HT.DisabledState.Parent = (TextBox)(object)txtOdds25HT;
		txtOdds25HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds25HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds25HT.FocusedState.Parent = (TextBox)(object)txtOdds25HT;
		((TextBox)txtOdds25HT).ForeColor = Color.Black;
		txtOdds25HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds25HT.HoveredState.Parent = (TextBox)(object)txtOdds25HT;
		((Control)txtOdds25HT).Location = new Point(218, 154);
		((Control)txtOdds25HT).Margin = new Padding(22, 44, 22, 44);
		((Control)txtOdds25HT).Name = "txtOdds25HT";
		((TextBox)txtOdds25HT).PasswordChar = '\0';
		txtOdds25HT.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds25HT).SelectedText = "";
		txtOdds25HT.ShadowDecoration.Parent = (Control)(object)txtOdds25HT;
		((Control)txtOdds25HT).Size = new Size(102, 29);
		((Control)txtOdds25HT).TabIndex = 51;
		((Control)txtStake25HT).Cursor = Cursors.IBeam;
		((TextBox)txtStake25HT).DefaultText = "5";
		txtStake25HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake25HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake25HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake25HT.DisabledState.Parent = (TextBox)(object)txtStake25HT;
		txtStake25HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake25HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake25HT.FocusedState.Parent = (TextBox)(object)txtStake25HT;
		((TextBox)txtStake25HT).ForeColor = Color.Black;
		txtStake25HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake25HT.HoveredState.Parent = (TextBox)(object)txtStake25HT;
		((Control)txtStake25HT).Location = new Point(111, 154);
		((Control)txtStake25HT).Margin = new Padding(13, 23, 13, 23);
		((Control)txtStake25HT).Name = "txtStake25HT";
		((TextBox)txtStake25HT).PasswordChar = '\0';
		txtStake25HT.PlaceholderText = "STAKE";
		((TextBox)txtStake25HT).SelectedText = "";
		txtStake25HT.ShadowDecoration.Parent = (Control)(object)txtStake25HT;
		((Control)txtStake25HT).Size = new Size(93, 29);
		((Control)txtStake25HT).TabIndex = 50;
		((Control)txtOdds15HT).Cursor = Cursors.IBeam;
		((TextBox)txtOdds15HT).DefaultText = "1.5";
		txtOdds15HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds15HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds15HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds15HT.DisabledState.Parent = (TextBox)(object)txtOdds15HT;
		txtOdds15HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds15HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds15HT.FocusedState.Parent = (TextBox)(object)txtOdds15HT;
		((TextBox)txtOdds15HT).ForeColor = Color.Black;
		txtOdds15HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds15HT.HoveredState.Parent = (TextBox)(object)txtOdds15HT;
		((Control)txtOdds15HT).Location = new Point(218, 113);
		((Control)txtOdds15HT).Margin = new Padding(13, 23, 13, 23);
		((Control)txtOdds15HT).Name = "txtOdds15HT";
		((TextBox)txtOdds15HT).PasswordChar = '\0';
		txtOdds15HT.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds15HT).SelectedText = "";
		txtOdds15HT.ShadowDecoration.Parent = (Control)(object)txtOdds15HT;
		((Control)txtOdds15HT).Size = new Size(102, 29);
		((Control)txtOdds15HT).TabIndex = 48;
		((Control)txtStake15HT).Cursor = Cursors.IBeam;
		((TextBox)txtStake15HT).DefaultText = "5";
		txtStake15HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake15HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake15HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake15HT.DisabledState.Parent = (TextBox)(object)txtStake15HT;
		txtStake15HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake15HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake15HT.FocusedState.Parent = (TextBox)(object)txtStake15HT;
		((TextBox)txtStake15HT).ForeColor = Color.Black;
		txtStake15HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake15HT.HoveredState.Parent = (TextBox)(object)txtStake15HT;
		((Control)txtStake15HT).Location = new Point(111, 113);
		((Control)txtStake15HT).Margin = new Padding(8, 12, 8, 12);
		((Control)txtStake15HT).Name = "txtStake15HT";
		((TextBox)txtStake15HT).PasswordChar = '\0';
		txtStake15HT.PlaceholderText = "STAKE";
		((TextBox)txtStake15HT).SelectedText = "";
		txtStake15HT.ShadowDecoration.Parent = (Control)(object)txtStake15HT;
		((Control)txtStake15HT).Size = new Size(93, 29);
		((Control)txtStake15HT).TabIndex = 47;
		((Control)txtOdds05HT).Cursor = Cursors.IBeam;
		((TextBox)txtOdds05HT).DefaultText = "1.5";
		txtOdds05HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOdds05HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOdds05HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOdds05HT.DisabledState.Parent = (TextBox)(object)txtOdds05HT;
		txtOdds05HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOdds05HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds05HT.FocusedState.Parent = (TextBox)(object)txtOdds05HT;
		((TextBox)txtOdds05HT).ForeColor = Color.Black;
		txtOdds05HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOdds05HT.HoveredState.Parent = (TextBox)(object)txtOdds05HT;
		((Control)txtOdds05HT).Location = new Point(218, 73);
		((Control)txtOdds05HT).Margin = new Padding(8, 12, 8, 12);
		((Control)txtOdds05HT).Name = "txtOdds05HT";
		((TextBox)txtOdds05HT).PasswordChar = '\0';
		txtOdds05HT.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOdds05HT).SelectedText = "";
		txtOdds05HT.ShadowDecoration.Parent = (Control)(object)txtOdds05HT;
		((Control)txtOdds05HT).Size = new Size(102, 29);
		((Control)txtOdds05HT).TabIndex = 46;
		((Control)txtStake05HT).Cursor = Cursors.IBeam;
		((TextBox)txtStake05HT).DefaultText = "5";
		txtStake05HT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake05HT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake05HT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake05HT.DisabledState.Parent = (TextBox)(object)txtStake05HT;
		txtStake05HT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake05HT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake05HT.FocusedState.Parent = (TextBox)(object)txtStake05HT;
		((TextBox)txtStake05HT).ForeColor = Color.Black;
		txtStake05HT.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake05HT.HoveredState.Parent = (TextBox)(object)txtStake05HT;
		((Control)txtStake05HT).Location = new Point(111, 73);
		((Control)txtStake05HT).Margin = new Padding(5, 6, 5, 6);
		((Control)txtStake05HT).Name = "txtStake05HT";
		((TextBox)txtStake05HT).PasswordChar = '\0';
		txtStake05HT.PlaceholderText = "STAKE";
		((TextBox)txtStake05HT).SelectedText = "";
		txtStake05HT.ShadowDecoration.Parent = (Control)(object)txtStake05HT;
		((Control)txtStake05HT).Size = new Size(93, 29);
		((Control)txtStake05HT).TabIndex = 45;
		((Control)siticoneHtmlLabel17).BackColor = Color.Transparent;
		siticoneHtmlLabel17.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel17.ForeColor = Color.White;
		((Control)siticoneHtmlLabel17).Location = new Point(7, 76);
		((Control)siticoneHtmlLabel17).Name = "siticoneHtmlLabel17";
		((Control)siticoneHtmlLabel17).Size = new Size(87, 21);
		((Control)siticoneHtmlLabel17).TabIndex = 44;
		((Control)siticoneHtmlLabel17).Text = "OVER 0.5 HT : ";
		((Control)siticoneGroupBox3).BackColor = Color.Transparent;
		siticoneGroupBox3.BorderThickness = 0;
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds80m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake80m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel9);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds70m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake70m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel10);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds60m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake60m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel11);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds50m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake50m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel13);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds40m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake40m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel14);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel18);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds30m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake30m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel19);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds20m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake20m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtodds10m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)txtStake10m);
		((Control)siticoneGroupBox3).Controls.Add((Control)(object)siticoneHtmlLabel20);
		siticoneGroupBox3.CustomBorderColor = Color.FromArgb(60, 62, 118);
		siticoneGroupBox3.FillColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGroupBox3).Font = new Font("Bahnschrift SemiCondensed", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneGroupBox3).ForeColor = Color.Salmon;
		((Control)siticoneGroupBox3).Location = new Point(394, 65);
		((Control)siticoneGroupBox3).Name = "siticoneGroupBox3";
		((Control)siticoneGroupBox3).Size = new Size(381, 383);
		((Control)siticoneGroupBox3).TabIndex = 56;
		((Control)siticoneGroupBox3).Text = "OVER IN MINUTES";
		siticoneGroupBox3.TextAlign = (HorizontalAlignment)2;
		((Control)txtodds80m).Cursor = Cursors.IBeam;
		((TextBox)txtodds80m).DefaultText = "1.5";
		txtodds80m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds80m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds80m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds80m.DisabledState.Parent = (TextBox)(object)txtodds80m;
		txtodds80m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds80m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds80m.FocusedState.Parent = (TextBox)(object)txtodds80m;
		((TextBox)txtodds80m).ForeColor = Color.Black;
		txtodds80m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds80m.HoveredState.Parent = (TextBox)(object)txtodds80m;
		((Control)txtodds80m).Location = new Point(257, 338);
		((Control)txtodds80m).Margin = new Padding(287, 1158, 287, 1158);
		((Control)txtodds80m).Name = "txtodds80m";
		((TextBox)txtodds80m).PasswordChar = '\0';
		txtodds80m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds80m).SelectedText = "";
		txtodds80m.ShadowDecoration.Parent = (Control)(object)txtodds80m;
		((Control)txtodds80m).Size = new Size(102, 29);
		((Control)txtodds80m).TabIndex = 67;
		((Control)txtStake80m).Cursor = Cursors.IBeam;
		((TextBox)txtStake80m).DefaultText = "5";
		txtStake80m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake80m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake80m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake80m.DisabledState.Parent = (TextBox)(object)txtStake80m;
		txtStake80m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake80m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake80m.FocusedState.Parent = (TextBox)(object)txtStake80m;
		((TextBox)txtStake80m).ForeColor = Color.Black;
		txtStake80m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake80m.HoveredState.Parent = (TextBox)(object)txtStake80m;
		((Control)txtStake80m).Location = new Point(150, 338);
		((Control)txtStake80m).Margin = new Padding(172, 602, 172, 602);
		((Control)txtStake80m).Name = "txtStake80m";
		((TextBox)txtStake80m).PasswordChar = '\0';
		txtStake80m.PlaceholderText = "STAKE";
		((TextBox)txtStake80m).SelectedText = "";
		txtStake80m.ShadowDecoration.Parent = (Control)(object)txtStake80m;
		((Control)txtStake80m).Size = new Size(93, 29);
		((Control)txtStake80m).TabIndex = 66;
		((Control)siticoneHtmlLabel9).BackColor = Color.Transparent;
		siticoneHtmlLabel9.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel9.ForeColor = Color.White;
		((Control)siticoneHtmlLabel9).Location = new Point(18, 341);
		((Control)siticoneHtmlLabel9).Name = "siticoneHtmlLabel9";
		((Control)siticoneHtmlLabel9).Size = new Size(104, 21);
		((Control)siticoneHtmlLabel9).TabIndex = 65;
		((Control)siticoneHtmlLabel9).Text = "BEFORE 80 MIN:";
		((Control)txtodds70m).Cursor = Cursors.IBeam;
		((TextBox)txtodds70m).DefaultText = "1.5";
		txtodds70m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds70m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds70m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds70m.DisabledState.Parent = (TextBox)(object)txtodds70m;
		txtodds70m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds70m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds70m.FocusedState.Parent = (TextBox)(object)txtodds70m;
		((TextBox)txtodds70m).ForeColor = Color.Black;
		txtodds70m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds70m.HoveredState.Parent = (TextBox)(object)txtodds70m;
		((Control)txtodds70m).Location = new Point(257, 298);
		((Control)txtodds70m).Margin = new Padding(172, 602, 172, 602);
		((Control)txtodds70m).Name = "txtodds70m";
		((TextBox)txtodds70m).PasswordChar = '\0';
		txtodds70m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds70m).SelectedText = "";
		txtodds70m.ShadowDecoration.Parent = (Control)(object)txtodds70m;
		((Control)txtodds70m).Size = new Size(102, 29);
		((Control)txtodds70m).TabIndex = 64;
		((Control)txtStake70m).Cursor = Cursors.IBeam;
		((TextBox)txtStake70m).DefaultText = "5";
		txtStake70m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake70m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake70m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake70m.DisabledState.Parent = (TextBox)(object)txtStake70m;
		txtStake70m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake70m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake70m.FocusedState.Parent = (TextBox)(object)txtStake70m;
		((TextBox)txtStake70m).ForeColor = Color.Black;
		txtStake70m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake70m.HoveredState.Parent = (TextBox)(object)txtStake70m;
		((Control)txtStake70m).Location = new Point(150, 298);
		((Control)txtStake70m).Margin = new Padding(103, 313, 103, 313);
		((Control)txtStake70m).Name = "txtStake70m";
		((TextBox)txtStake70m).PasswordChar = '\0';
		txtStake70m.PlaceholderText = "STAKE";
		((TextBox)txtStake70m).SelectedText = "";
		txtStake70m.ShadowDecoration.Parent = (Control)(object)txtStake70m;
		((Control)txtStake70m).Size = new Size(93, 29);
		((Control)txtStake70m).TabIndex = 63;
		((Control)siticoneHtmlLabel10).BackColor = Color.Transparent;
		siticoneHtmlLabel10.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel10.ForeColor = Color.White;
		((Control)siticoneHtmlLabel10).Location = new Point(17, 302);
		((Control)siticoneHtmlLabel10).Name = "siticoneHtmlLabel10";
		((Control)siticoneHtmlLabel10).Size = new Size(103, 21);
		((Control)siticoneHtmlLabel10).TabIndex = 62;
		((Control)siticoneHtmlLabel10).Text = "BEFORE 70 MIN:";
		((Control)txtodds60m).Cursor = Cursors.IBeam;
		((TextBox)txtodds60m).DefaultText = "1.5";
		txtodds60m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds60m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds60m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds60m.DisabledState.Parent = (TextBox)(object)txtodds60m;
		txtodds60m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds60m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds60m.FocusedState.Parent = (TextBox)(object)txtodds60m;
		((TextBox)txtodds60m).ForeColor = Color.Black;
		txtodds60m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds60m.HoveredState.Parent = (TextBox)(object)txtodds60m;
		((Control)txtodds60m).Location = new Point(257, 258);
		((Control)txtodds60m).Margin = new Padding(103, 313, 103, 313);
		((Control)txtodds60m).Name = "txtodds60m";
		((TextBox)txtodds60m).PasswordChar = '\0';
		txtodds60m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds60m).SelectedText = "";
		txtodds60m.ShadowDecoration.Parent = (Control)(object)txtodds60m;
		((Control)txtodds60m).Size = new Size(102, 29);
		((Control)txtodds60m).TabIndex = 61;
		((Control)txtStake60m).Cursor = Cursors.IBeam;
		((TextBox)txtStake60m).DefaultText = "5";
		txtStake60m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake60m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake60m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake60m.DisabledState.Parent = (TextBox)(object)txtStake60m;
		txtStake60m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake60m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake60m.FocusedState.Parent = (TextBox)(object)txtStake60m;
		((TextBox)txtStake60m).ForeColor = Color.Black;
		txtStake60m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake60m.HoveredState.Parent = (TextBox)(object)txtStake60m;
		((Control)txtStake60m).Location = new Point(150, 258);
		((Control)txtStake60m).Margin = new Padding(62, 163, 62, 163);
		((Control)txtStake60m).Name = "txtStake60m";
		((TextBox)txtStake60m).PasswordChar = '\0';
		txtStake60m.PlaceholderText = "STAKE";
		((TextBox)txtStake60m).SelectedText = "";
		txtStake60m.ShadowDecoration.Parent = (Control)(object)txtStake60m;
		((Control)txtStake60m).Size = new Size(93, 29);
		((Control)txtStake60m).TabIndex = 60;
		((Control)siticoneHtmlLabel11).BackColor = Color.Transparent;
		siticoneHtmlLabel11.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel11.ForeColor = Color.White;
		((Control)siticoneHtmlLabel11).Location = new Point(18, 262);
		((Control)siticoneHtmlLabel11).Name = "siticoneHtmlLabel11";
		((Control)siticoneHtmlLabel11).Size = new Size(103, 21);
		((Control)siticoneHtmlLabel11).TabIndex = 59;
		((Control)siticoneHtmlLabel11).Text = "BEFORE 60 MIN:";
		((Control)txtodds50m).Cursor = Cursors.IBeam;
		((TextBox)txtodds50m).DefaultText = "1.5";
		txtodds50m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds50m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds50m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds50m.DisabledState.Parent = (TextBox)(object)txtodds50m;
		txtodds50m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds50m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds50m.FocusedState.Parent = (TextBox)(object)txtodds50m;
		((TextBox)txtodds50m).ForeColor = Color.Black;
		txtodds50m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds50m.HoveredState.Parent = (TextBox)(object)txtodds50m;
		((Control)txtodds50m).Location = new Point(257, 218);
		((Control)txtodds50m).Margin = new Padding(62, 163, 62, 163);
		((Control)txtodds50m).Name = "txtodds50m";
		((TextBox)txtodds50m).PasswordChar = '\0';
		txtodds50m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds50m).SelectedText = "";
		txtodds50m.ShadowDecoration.Parent = (Control)(object)txtodds50m;
		((Control)txtodds50m).Size = new Size(102, 29);
		((Control)txtodds50m).TabIndex = 58;
		((Control)txtStake50m).Cursor = Cursors.IBeam;
		((TextBox)txtStake50m).DefaultText = "5";
		txtStake50m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake50m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake50m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake50m.DisabledState.Parent = (TextBox)(object)txtStake50m;
		txtStake50m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake50m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake50m.FocusedState.Parent = (TextBox)(object)txtStake50m;
		((TextBox)txtStake50m).ForeColor = Color.Black;
		txtStake50m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake50m.HoveredState.Parent = (TextBox)(object)txtStake50m;
		((Control)txtStake50m).Location = new Point(150, 218);
		((Control)txtStake50m).Margin = new Padding(37, 85, 37, 85);
		((Control)txtStake50m).Name = "txtStake50m";
		((TextBox)txtStake50m).PasswordChar = '\0';
		txtStake50m.PlaceholderText = "STAKE";
		((TextBox)txtStake50m).SelectedText = "";
		txtStake50m.ShadowDecoration.Parent = (Control)(object)txtStake50m;
		((Control)txtStake50m).Size = new Size(93, 29);
		((Control)txtStake50m).TabIndex = 57;
		((Control)siticoneHtmlLabel13).BackColor = Color.Transparent;
		siticoneHtmlLabel13.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel13.ForeColor = Color.White;
		((Control)siticoneHtmlLabel13).Location = new Point(18, 222);
		((Control)siticoneHtmlLabel13).Name = "siticoneHtmlLabel13";
		((Control)siticoneHtmlLabel13).Size = new Size(104, 21);
		((Control)siticoneHtmlLabel13).TabIndex = 56;
		((Control)siticoneHtmlLabel13).Text = "BEFORE 50 MIN:";
		((Control)txtodds40m).Cursor = Cursors.IBeam;
		((TextBox)txtodds40m).DefaultText = "1.5";
		txtodds40m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds40m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds40m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds40m.DisabledState.Parent = (TextBox)(object)txtodds40m;
		txtodds40m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds40m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds40m.FocusedState.Parent = (TextBox)(object)txtodds40m;
		((TextBox)txtodds40m).ForeColor = Color.Black;
		txtodds40m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds40m.HoveredState.Parent = (TextBox)(object)txtodds40m;
		((Control)txtodds40m).Location = new Point(257, 179);
		((Control)txtodds40m).Margin = new Padding(37, 85, 37, 85);
		((Control)txtodds40m).Name = "txtodds40m";
		((TextBox)txtodds40m).PasswordChar = '\0';
		txtodds40m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds40m).SelectedText = "";
		txtodds40m.ShadowDecoration.Parent = (Control)(object)txtodds40m;
		((Control)txtodds40m).Size = new Size(102, 29);
		((Control)txtodds40m).TabIndex = 55;
		((Control)txtStake40m).Cursor = Cursors.IBeam;
		((TextBox)txtStake40m).DefaultText = "5";
		txtStake40m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake40m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake40m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake40m.DisabledState.Parent = (TextBox)(object)txtStake40m;
		txtStake40m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake40m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake40m.FocusedState.Parent = (TextBox)(object)txtStake40m;
		((TextBox)txtStake40m).ForeColor = Color.Black;
		txtStake40m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake40m.HoveredState.Parent = (TextBox)(object)txtStake40m;
		((Control)txtStake40m).Location = new Point(150, 179);
		((Control)txtStake40m).Margin = new Padding(22, 44, 22, 44);
		((Control)txtStake40m).Name = "txtStake40m";
		((TextBox)txtStake40m).PasswordChar = '\0';
		txtStake40m.PlaceholderText = "STAKE";
		((TextBox)txtStake40m).SelectedText = "";
		txtStake40m.ShadowDecoration.Parent = (Control)(object)txtStake40m;
		((Control)txtStake40m).Size = new Size(93, 29);
		((Control)txtStake40m).TabIndex = 54;
		((Control)siticoneHtmlLabel14).BackColor = Color.Transparent;
		siticoneHtmlLabel14.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel14.ForeColor = Color.White;
		((Control)siticoneHtmlLabel14).Location = new Point(18, 184);
		((Control)siticoneHtmlLabel14).Name = "siticoneHtmlLabel14";
		((Control)siticoneHtmlLabel14).Size = new Size(104, 21);
		((Control)siticoneHtmlLabel14).TabIndex = 53;
		((Control)siticoneHtmlLabel14).Text = "BEFORE 40 MIN:";
		((Control)siticoneHtmlLabel18).BackColor = Color.Transparent;
		siticoneHtmlLabel18.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel18.ForeColor = Color.White;
		((Control)siticoneHtmlLabel18).Location = new Point(18, 143);
		((Control)siticoneHtmlLabel18).Name = "siticoneHtmlLabel18";
		((Control)siticoneHtmlLabel18).Size = new Size(103, 21);
		((Control)siticoneHtmlLabel18).TabIndex = 52;
		((Control)siticoneHtmlLabel18).Text = "BEFORE 30 MIN:";
		((Control)txtodds30m).Cursor = Cursors.IBeam;
		((TextBox)txtodds30m).DefaultText = "1.5";
		txtodds30m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds30m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds30m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds30m.DisabledState.Parent = (TextBox)(object)txtodds30m;
		txtodds30m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds30m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds30m.FocusedState.Parent = (TextBox)(object)txtodds30m;
		((TextBox)txtodds30m).ForeColor = Color.Black;
		txtodds30m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds30m.HoveredState.Parent = (TextBox)(object)txtodds30m;
		((Control)txtodds30m).Location = new Point(257, 138);
		((Control)txtodds30m).Margin = new Padding(22, 44, 22, 44);
		((Control)txtodds30m).Name = "txtodds30m";
		((TextBox)txtodds30m).PasswordChar = '\0';
		txtodds30m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds30m).SelectedText = "";
		txtodds30m.ShadowDecoration.Parent = (Control)(object)txtodds30m;
		((Control)txtodds30m).Size = new Size(102, 29);
		((Control)txtodds30m).TabIndex = 51;
		((Control)txtStake30m).Cursor = Cursors.IBeam;
		((TextBox)txtStake30m).DefaultText = "5";
		txtStake30m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake30m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake30m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake30m.DisabledState.Parent = (TextBox)(object)txtStake30m;
		txtStake30m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake30m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake30m.FocusedState.Parent = (TextBox)(object)txtStake30m;
		((TextBox)txtStake30m).ForeColor = Color.Black;
		txtStake30m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake30m.HoveredState.Parent = (TextBox)(object)txtStake30m;
		((Control)txtStake30m).Location = new Point(150, 138);
		((Control)txtStake30m).Margin = new Padding(13, 23, 13, 23);
		((Control)txtStake30m).Name = "txtStake30m";
		((TextBox)txtStake30m).PasswordChar = '\0';
		txtStake30m.PlaceholderText = "STAKE";
		((TextBox)txtStake30m).SelectedText = "";
		txtStake30m.ShadowDecoration.Parent = (Control)(object)txtStake30m;
		((Control)txtStake30m).Size = new Size(93, 29);
		((Control)txtStake30m).TabIndex = 50;
		((Control)siticoneHtmlLabel19).BackColor = Color.Transparent;
		siticoneHtmlLabel19.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel19.ForeColor = Color.White;
		((Control)siticoneHtmlLabel19).Location = new Point(17, 101);
		((Control)siticoneHtmlLabel19).Name = "siticoneHtmlLabel19";
		((Control)siticoneHtmlLabel19).Size = new Size(103, 21);
		((Control)siticoneHtmlLabel19).TabIndex = 49;
		((Control)siticoneHtmlLabel19).Text = "BEFORE 20 MIN:";
		((Control)txtodds20m).Cursor = Cursors.IBeam;
		((TextBox)txtodds20m).DefaultText = "1.5";
		txtodds20m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds20m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds20m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds20m.DisabledState.Parent = (TextBox)(object)txtodds20m;
		txtodds20m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds20m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds20m.FocusedState.Parent = (TextBox)(object)txtodds20m;
		((TextBox)txtodds20m).ForeColor = Color.Black;
		txtodds20m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds20m.HoveredState.Parent = (TextBox)(object)txtodds20m;
		((Control)txtodds20m).Location = new Point(257, 97);
		((Control)txtodds20m).Margin = new Padding(13, 23, 13, 23);
		((Control)txtodds20m).Name = "txtodds20m";
		((TextBox)txtodds20m).PasswordChar = '\0';
		txtodds20m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds20m).SelectedText = "";
		txtodds20m.ShadowDecoration.Parent = (Control)(object)txtodds20m;
		((Control)txtodds20m).Size = new Size(102, 29);
		((Control)txtodds20m).TabIndex = 48;
		((Control)txtStake20m).Cursor = Cursors.IBeam;
		((TextBox)txtStake20m).DefaultText = "5";
		txtStake20m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake20m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake20m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake20m.DisabledState.Parent = (TextBox)(object)txtStake20m;
		txtStake20m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake20m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake20m.FocusedState.Parent = (TextBox)(object)txtStake20m;
		((TextBox)txtStake20m).ForeColor = Color.Black;
		txtStake20m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake20m.HoveredState.Parent = (TextBox)(object)txtStake20m;
		((Control)txtStake20m).Location = new Point(150, 97);
		((Control)txtStake20m).Margin = new Padding(8, 12, 8, 12);
		((Control)txtStake20m).Name = "txtStake20m";
		((TextBox)txtStake20m).PasswordChar = '\0';
		txtStake20m.PlaceholderText = "STAKE";
		((TextBox)txtStake20m).SelectedText = "";
		txtStake20m.ShadowDecoration.Parent = (Control)(object)txtStake20m;
		((Control)txtStake20m).Size = new Size(93, 29);
		((Control)txtStake20m).TabIndex = 47;
		((Control)txtodds10m).Cursor = Cursors.IBeam;
		((TextBox)txtodds10m).DefaultText = "1.5";
		txtodds10m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtodds10m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtodds10m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtodds10m.DisabledState.Parent = (TextBox)(object)txtodds10m;
		txtodds10m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtodds10m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds10m.FocusedState.Parent = (TextBox)(object)txtodds10m;
		((TextBox)txtodds10m).ForeColor = Color.Black;
		txtodds10m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtodds10m.HoveredState.Parent = (TextBox)(object)txtodds10m;
		((Control)txtodds10m).Location = new Point(257, 57);
		((Control)txtodds10m).Margin = new Padding(8, 12, 8, 12);
		((Control)txtodds10m).Name = "txtodds10m";
		((TextBox)txtodds10m).PasswordChar = '\0';
		txtodds10m.PlaceholderText = "MIN QUOTE";
		((TextBox)txtodds10m).SelectedText = "";
		txtodds10m.ShadowDecoration.Parent = (Control)(object)txtodds10m;
		((Control)txtodds10m).Size = new Size(102, 29);
		((Control)txtodds10m).TabIndex = 46;
		((Control)txtStake10m).Cursor = Cursors.IBeam;
		((TextBox)txtStake10m).DefaultText = "5";
		txtStake10m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStake10m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStake10m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStake10m.DisabledState.Parent = (TextBox)(object)txtStake10m;
		txtStake10m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStake10m.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake10m.FocusedState.Parent = (TextBox)(object)txtStake10m;
		((TextBox)txtStake10m).ForeColor = Color.Black;
		txtStake10m.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStake10m.HoveredState.Parent = (TextBox)(object)txtStake10m;
		((Control)txtStake10m).Location = new Point(150, 57);
		((Control)txtStake10m).Margin = new Padding(5, 6, 5, 6);
		((Control)txtStake10m).Name = "txtStake10m";
		((TextBox)txtStake10m).PasswordChar = '\0';
		txtStake10m.PlaceholderText = "STAKE";
		((TextBox)txtStake10m).SelectedText = "";
		txtStake10m.ShadowDecoration.Parent = (Control)(object)txtStake10m;
		((Control)txtStake10m).Size = new Size(93, 29);
		((Control)txtStake10m).TabIndex = 45;
		((Control)siticoneHtmlLabel20).BackColor = Color.Transparent;
		siticoneHtmlLabel20.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel20.ForeColor = Color.White;
		((Control)siticoneHtmlLabel20).Location = new Point(17, 60);
		((Control)siticoneHtmlLabel20).Name = "siticoneHtmlLabel20";
		((Control)siticoneHtmlLabel20).Size = new Size(101, 21);
		((Control)siticoneHtmlLabel20).TabIndex = 44;
		((Control)siticoneHtmlLabel20).Text = "BEFORE 10 MIN:";
		((Control)siticoneGroupBox4).BackColor = Color.Transparent;
		siticoneGroupBox4.BorderThickness = 0;
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)siticoneHtmlLabel22);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)siticoneHtmlLabel21);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtOddsU45);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtStakeU45);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtOddsU35);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtStakeU35);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtOddsU25);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)txtStakeU25);
		((Control)siticoneGroupBox4).Controls.Add((Control)(object)siticoneHtmlLabel23);
		siticoneGroupBox4.CustomBorderColor = Color.FromArgb(60, 62, 118);
		siticoneGroupBox4.FillColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGroupBox4).Font = new Font("Bahnschrift SemiCondensed", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneGroupBox4).ForeColor = Color.Salmon;
		((Control)siticoneGroupBox4).Location = new Point(394, 466);
		((Control)siticoneGroupBox4).Name = "siticoneGroupBox4";
		((Control)siticoneGroupBox4).Size = new Size(381, 221);
		((Control)siticoneGroupBox4).TabIndex = 57;
		((Control)siticoneGroupBox4).Text = "UNDER FULL TIME";
		siticoneGroupBox4.TextAlign = (HorizontalAlignment)2;
		((Control)siticoneHtmlLabel22).BackColor = Color.Transparent;
		siticoneHtmlLabel22.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel22.ForeColor = Color.White;
		((Control)siticoneHtmlLabel22).Location = new Point(44, 159);
		((Control)siticoneHtmlLabel22).Name = "siticoneHtmlLabel22";
		((Control)siticoneHtmlLabel22).Size = new Size(77, 21);
		((Control)siticoneHtmlLabel22).TabIndex = 53;
		((Control)siticoneHtmlLabel22).Text = "UNDER 4.5 :";
		((Control)siticoneHtmlLabel21).BackColor = Color.Transparent;
		siticoneHtmlLabel21.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel21.ForeColor = Color.White;
		((Control)siticoneHtmlLabel21).Location = new Point(44, 117);
		((Control)siticoneHtmlLabel21).Name = "siticoneHtmlLabel21";
		((Control)siticoneHtmlLabel21).Size = new Size(76, 21);
		((Control)siticoneHtmlLabel21).TabIndex = 52;
		((Control)siticoneHtmlLabel21).Text = "UNDER 3.5 :";
		((Control)txtOddsU45).Cursor = Cursors.IBeam;
		((TextBox)txtOddsU45).DefaultText = "1.5";
		txtOddsU45.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddsU45.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddsU45.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU45.DisabledState.Parent = (TextBox)(object)txtOddsU45;
		txtOddsU45.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU45.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU45.FocusedState.Parent = (TextBox)(object)txtOddsU45;
		((TextBox)txtOddsU45).ForeColor = Color.Black;
		txtOddsU45.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU45.HoveredState.Parent = (TextBox)(object)txtOddsU45;
		((Control)txtOddsU45).Location = new Point(257, 154);
		((Control)txtOddsU45).Margin = new Padding(22, 44, 22, 44);
		((Control)txtOddsU45).Name = "txtOddsU45";
		((TextBox)txtOddsU45).PasswordChar = '\0';
		txtOddsU45.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddsU45).SelectedText = "";
		txtOddsU45.ShadowDecoration.Parent = (Control)(object)txtOddsU45;
		((Control)txtOddsU45).Size = new Size(102, 29);
		((Control)txtOddsU45).TabIndex = 51;
		((Control)txtStakeU45).Cursor = Cursors.IBeam;
		((TextBox)txtStakeU45).DefaultText = "5";
		txtStakeU45.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakeU45.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakeU45.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU45.DisabledState.Parent = (TextBox)(object)txtStakeU45;
		txtStakeU45.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU45.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU45.FocusedState.Parent = (TextBox)(object)txtStakeU45;
		((TextBox)txtStakeU45).ForeColor = Color.Black;
		txtStakeU45.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU45.HoveredState.Parent = (TextBox)(object)txtStakeU45;
		((Control)txtStakeU45).Location = new Point(150, 154);
		((Control)txtStakeU45).Margin = new Padding(13, 23, 13, 23);
		((Control)txtStakeU45).Name = "txtStakeU45";
		((TextBox)txtStakeU45).PasswordChar = '\0';
		txtStakeU45.PlaceholderText = "STAKE";
		((TextBox)txtStakeU45).SelectedText = "";
		txtStakeU45.ShadowDecoration.Parent = (Control)(object)txtStakeU45;
		((Control)txtStakeU45).Size = new Size(93, 29);
		((Control)txtStakeU45).TabIndex = 50;
		((Control)txtOddsU35).Cursor = Cursors.IBeam;
		((TextBox)txtOddsU35).DefaultText = "1.5";
		txtOddsU35.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddsU35.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddsU35.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU35.DisabledState.Parent = (TextBox)(object)txtOddsU35;
		txtOddsU35.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU35.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU35.FocusedState.Parent = (TextBox)(object)txtOddsU35;
		((TextBox)txtOddsU35).ForeColor = Color.Black;
		txtOddsU35.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU35.HoveredState.Parent = (TextBox)(object)txtOddsU35;
		((Control)txtOddsU35).Location = new Point(257, 113);
		((Control)txtOddsU35).Margin = new Padding(13, 23, 13, 23);
		((Control)txtOddsU35).Name = "txtOddsU35";
		((TextBox)txtOddsU35).PasswordChar = '\0';
		txtOddsU35.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddsU35).SelectedText = "";
		txtOddsU35.ShadowDecoration.Parent = (Control)(object)txtOddsU35;
		((Control)txtOddsU35).Size = new Size(102, 29);
		((Control)txtOddsU35).TabIndex = 48;
		((Control)txtStakeU35).Cursor = Cursors.IBeam;
		((TextBox)txtStakeU35).DefaultText = "5";
		txtStakeU35.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakeU35.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakeU35.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU35.DisabledState.Parent = (TextBox)(object)txtStakeU35;
		txtStakeU35.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU35.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU35.FocusedState.Parent = (TextBox)(object)txtStakeU35;
		((TextBox)txtStakeU35).ForeColor = Color.Black;
		txtStakeU35.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU35.HoveredState.Parent = (TextBox)(object)txtStakeU35;
		((Control)txtStakeU35).Location = new Point(150, 113);
		((Control)txtStakeU35).Margin = new Padding(8, 12, 8, 12);
		((Control)txtStakeU35).Name = "txtStakeU35";
		((TextBox)txtStakeU35).PasswordChar = '\0';
		txtStakeU35.PlaceholderText = "STAKE";
		((TextBox)txtStakeU35).SelectedText = "";
		txtStakeU35.ShadowDecoration.Parent = (Control)(object)txtStakeU35;
		((Control)txtStakeU35).Size = new Size(93, 29);
		((Control)txtStakeU35).TabIndex = 47;
		((Control)txtOddsU25).Cursor = Cursors.IBeam;
		((TextBox)txtOddsU25).DefaultText = "1.5";
		txtOddsU25.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddsU25.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddsU25.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU25.DisabledState.Parent = (TextBox)(object)txtOddsU25;
		txtOddsU25.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddsU25.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU25.FocusedState.Parent = (TextBox)(object)txtOddsU25;
		((TextBox)txtOddsU25).ForeColor = Color.Black;
		txtOddsU25.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsU25.HoveredState.Parent = (TextBox)(object)txtOddsU25;
		((Control)txtOddsU25).Location = new Point(257, 73);
		((Control)txtOddsU25).Margin = new Padding(8, 12, 8, 12);
		((Control)txtOddsU25).Name = "txtOddsU25";
		((TextBox)txtOddsU25).PasswordChar = '\0';
		txtOddsU25.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddsU25).SelectedText = "";
		txtOddsU25.ShadowDecoration.Parent = (Control)(object)txtOddsU25;
		((Control)txtOddsU25).Size = new Size(102, 29);
		((Control)txtOddsU25).TabIndex = 46;
		((Control)txtStakeU25).Cursor = Cursors.IBeam;
		((TextBox)txtStakeU25).DefaultText = "5";
		txtStakeU25.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakeU25.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakeU25.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU25.DisabledState.Parent = (TextBox)(object)txtStakeU25;
		txtStakeU25.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakeU25.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU25.FocusedState.Parent = (TextBox)(object)txtStakeU25;
		((TextBox)txtStakeU25).ForeColor = Color.Black;
		txtStakeU25.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeU25.HoveredState.Parent = (TextBox)(object)txtStakeU25;
		((Control)txtStakeU25).Location = new Point(150, 73);
		((Control)txtStakeU25).Margin = new Padding(5, 6, 5, 6);
		((Control)txtStakeU25).Name = "txtStakeU25";
		((TextBox)txtStakeU25).PasswordChar = '\0';
		txtStakeU25.PlaceholderText = "STAKE";
		((TextBox)txtStakeU25).SelectedText = "";
		txtStakeU25.ShadowDecoration.Parent = (Control)(object)txtStakeU25;
		((Control)txtStakeU25).Size = new Size(93, 29);
		((Control)txtStakeU25).TabIndex = 45;
		((Control)siticoneHtmlLabel23).BackColor = Color.Transparent;
		siticoneHtmlLabel23.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel23.ForeColor = Color.White;
		((Control)siticoneHtmlLabel23).Location = new Point(44, 76);
		((Control)siticoneHtmlLabel23).Name = "siticoneHtmlLabel23";
		((Control)siticoneHtmlLabel23).Size = new Size(76, 21);
		((Control)siticoneHtmlLabel23).TabIndex = 44;
		((Control)siticoneHtmlLabel23).Text = "UNDER 2.5 :";
		((Control)siticoneGroupBox5).BackColor = Color.Transparent;
		siticoneGroupBox5.BorderThickness = 0;
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)siticoneHtmlLabel24);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)siticoneHtmlLabel25);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtOddsGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtStakeGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtOddsAGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtStakeAGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtOddshGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)txtStakehGoal);
		((Control)siticoneGroupBox5).Controls.Add((Control)(object)siticoneHtmlLabel26);
		siticoneGroupBox5.CustomBorderColor = Color.FromArgb(60, 62, 118);
		siticoneGroupBox5.FillColor = Color.FromArgb(55, 57, 108);
		((Control)siticoneGroupBox5).Font = new Font("Bahnschrift SemiCondensed", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)siticoneGroupBox5).ForeColor = Color.Salmon;
		((Control)siticoneGroupBox5).Location = new Point(793, 65);
		((Control)siticoneGroupBox5).Name = "siticoneGroupBox5";
		((Control)siticoneGroupBox5).Size = new Size(422, 221);
		((Control)siticoneGroupBox5).TabIndex = 58;
		((Control)siticoneGroupBox5).Text = "OTHER";
		siticoneGroupBox5.TextAlign = (HorizontalAlignment)2;
		((Control)siticoneHtmlLabel24).BackColor = Color.Transparent;
		siticoneHtmlLabel24.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel24.ForeColor = Color.White;
		((Control)siticoneHtmlLabel24).Location = new Point(95, 163);
		((Control)siticoneHtmlLabel24).Name = "siticoneHtmlLabel24";
		((Control)siticoneHtmlLabel24).Size = new Size(80, 21);
		((Control)siticoneHtmlLabel24).TabIndex = 71;
		((Control)siticoneHtmlLabel24).Text = "GOAL GOAL:";
		((Control)siticoneHtmlLabel25).BackColor = Color.Transparent;
		siticoneHtmlLabel25.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel25.ForeColor = Color.White;
		((Control)siticoneHtmlLabel25).Location = new Point(15, 123);
		((Control)siticoneHtmlLabel25).Name = "siticoneHtmlLabel25";
		((Control)siticoneHtmlLabel25).Size = new Size(160, 21);
		((Control)siticoneHtmlLabel25).TabIndex = 70;
		((Control)siticoneHtmlLabel25).Text = "NEXT GOAL AWAY TEAM : ";
		((Control)txtOddsGoal).Cursor = Cursors.IBeam;
		((TextBox)txtOddsGoal).DefaultText = "1.5";
		txtOddsGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddsGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddsGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddsGoal.DisabledState.Parent = (TextBox)(object)txtOddsGoal;
		txtOddsGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddsGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsGoal.FocusedState.Parent = (TextBox)(object)txtOddsGoal;
		((TextBox)txtOddsGoal).ForeColor = Color.Black;
		txtOddsGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsGoal.HoveredState.Parent = (TextBox)(object)txtOddsGoal;
		((Control)txtOddsGoal).Location = new Point(300, 159);
		((Control)txtOddsGoal).Margin = new Padding(22, 44, 22, 44);
		((Control)txtOddsGoal).Name = "txtOddsGoal";
		((TextBox)txtOddsGoal).PasswordChar = '\0';
		txtOddsGoal.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddsGoal).SelectedText = "";
		txtOddsGoal.ShadowDecoration.Parent = (Control)(object)txtOddsGoal;
		((Control)txtOddsGoal).Size = new Size(102, 29);
		((Control)txtOddsGoal).TabIndex = 51;
		((Control)txtStakeGoal).Cursor = Cursors.IBeam;
		((TextBox)txtStakeGoal).DefaultText = "5";
		txtStakeGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakeGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakeGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakeGoal.DisabledState.Parent = (TextBox)(object)txtStakeGoal;
		txtStakeGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakeGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeGoal.FocusedState.Parent = (TextBox)(object)txtStakeGoal;
		((TextBox)txtStakeGoal).ForeColor = Color.Black;
		txtStakeGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeGoal.HoveredState.Parent = (TextBox)(object)txtStakeGoal;
		((Control)txtStakeGoal).Location = new Point(193, 159);
		((Control)txtStakeGoal).Margin = new Padding(13, 23, 13, 23);
		((Control)txtStakeGoal).Name = "txtStakeGoal";
		((TextBox)txtStakeGoal).PasswordChar = '\0';
		txtStakeGoal.PlaceholderText = "STAKE";
		((TextBox)txtStakeGoal).SelectedText = "";
		txtStakeGoal.ShadowDecoration.Parent = (Control)(object)txtStakeGoal;
		((Control)txtStakeGoal).Size = new Size(93, 29);
		((Control)txtStakeGoal).TabIndex = 50;
		((Control)txtOddsAGoal).Cursor = Cursors.IBeam;
		((TextBox)txtOddsAGoal).DefaultText = "1.5";
		txtOddsAGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddsAGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddsAGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddsAGoal.DisabledState.Parent = (TextBox)(object)txtOddsAGoal;
		txtOddsAGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddsAGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsAGoal.FocusedState.Parent = (TextBox)(object)txtOddsAGoal;
		((TextBox)txtOddsAGoal).ForeColor = Color.Black;
		txtOddsAGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddsAGoal.HoveredState.Parent = (TextBox)(object)txtOddsAGoal;
		((Control)txtOddsAGoal).Location = new Point(300, 118);
		((Control)txtOddsAGoal).Margin = new Padding(13, 23, 13, 23);
		((Control)txtOddsAGoal).Name = "txtOddsAGoal";
		((TextBox)txtOddsAGoal).PasswordChar = '\0';
		txtOddsAGoal.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddsAGoal).SelectedText = "";
		txtOddsAGoal.ShadowDecoration.Parent = (Control)(object)txtOddsAGoal;
		((Control)txtOddsAGoal).Size = new Size(102, 29);
		((Control)txtOddsAGoal).TabIndex = 48;
		((Control)txtStakeAGoal).Cursor = Cursors.IBeam;
		((TextBox)txtStakeAGoal).DefaultText = "5";
		txtStakeAGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakeAGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakeAGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakeAGoal.DisabledState.Parent = (TextBox)(object)txtStakeAGoal;
		txtStakeAGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakeAGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeAGoal.FocusedState.Parent = (TextBox)(object)txtStakeAGoal;
		((TextBox)txtStakeAGoal).ForeColor = Color.Black;
		txtStakeAGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakeAGoal.HoveredState.Parent = (TextBox)(object)txtStakeAGoal;
		((Control)txtStakeAGoal).Location = new Point(193, 118);
		((Control)txtStakeAGoal).Margin = new Padding(8, 12, 8, 12);
		((Control)txtStakeAGoal).Name = "txtStakeAGoal";
		((TextBox)txtStakeAGoal).PasswordChar = '\0';
		txtStakeAGoal.PlaceholderText = "STAKE";
		((TextBox)txtStakeAGoal).SelectedText = "";
		txtStakeAGoal.ShadowDecoration.Parent = (Control)(object)txtStakeAGoal;
		((Control)txtStakeAGoal).Size = new Size(93, 29);
		((Control)txtStakeAGoal).TabIndex = 47;
		((Control)txtOddshGoal).Cursor = Cursors.IBeam;
		((TextBox)txtOddshGoal).DefaultText = "1.5";
		txtOddshGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtOddshGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtOddshGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtOddshGoal.DisabledState.Parent = (TextBox)(object)txtOddshGoal;
		txtOddshGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtOddshGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddshGoal.FocusedState.Parent = (TextBox)(object)txtOddshGoal;
		((TextBox)txtOddshGoal).ForeColor = Color.Black;
		txtOddshGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtOddshGoal.HoveredState.Parent = (TextBox)(object)txtOddshGoal;
		((Control)txtOddshGoal).Location = new Point(300, 78);
		((Control)txtOddshGoal).Margin = new Padding(8, 12, 8, 12);
		((Control)txtOddshGoal).Name = "txtOddshGoal";
		((TextBox)txtOddshGoal).PasswordChar = '\0';
		txtOddshGoal.PlaceholderText = "MIN QUOTE";
		((TextBox)txtOddshGoal).SelectedText = "";
		txtOddshGoal.ShadowDecoration.Parent = (Control)(object)txtOddshGoal;
		((Control)txtOddshGoal).Size = new Size(102, 29);
		((Control)txtOddshGoal).TabIndex = 46;
		((Control)txtStakehGoal).Cursor = Cursors.IBeam;
		((TextBox)txtStakehGoal).DefaultText = "5";
		txtStakehGoal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		txtStakehGoal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		txtStakehGoal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		txtStakehGoal.DisabledState.Parent = (TextBox)(object)txtStakehGoal;
		txtStakehGoal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		txtStakehGoal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakehGoal.FocusedState.Parent = (TextBox)(object)txtStakehGoal;
		((TextBox)txtStakehGoal).ForeColor = Color.Black;
		txtStakehGoal.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		txtStakehGoal.HoveredState.Parent = (TextBox)(object)txtStakehGoal;
		((Control)txtStakehGoal).Location = new Point(193, 78);
		((Control)txtStakehGoal).Margin = new Padding(5, 6, 5, 6);
		((Control)txtStakehGoal).Name = "txtStakehGoal";
		((TextBox)txtStakehGoal).PasswordChar = '\0';
		txtStakehGoal.PlaceholderText = "STAKE";
		((TextBox)txtStakehGoal).SelectedText = "";
		txtStakehGoal.ShadowDecoration.Parent = (Control)(object)txtStakehGoal;
		((Control)txtStakehGoal).Size = new Size(93, 29);
		((Control)txtStakehGoal).TabIndex = 45;
		((Control)siticoneHtmlLabel26).BackColor = Color.Transparent;
		siticoneHtmlLabel26.Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		siticoneHtmlLabel26.ForeColor = Color.White;
		((Control)siticoneHtmlLabel26).Location = new Point(15, 82);
		((Control)siticoneHtmlLabel26).Name = "siticoneHtmlLabel26";
		((Control)siticoneHtmlLabel26).Size = new Size(161, 21);
		((Control)siticoneHtmlLabel26).TabIndex = 44;
		((Control)siticoneHtmlLabel26).Text = "NEXT GOAL HOME TEAM : ";
		btnCancel.DisabledState.BorderColor = Color.DarkGray;
		btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
		btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnCancel.FillColor = Color.FromArgb(192, 64, 0);
		((Control)btnCancel).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnCancel).ForeColor = Color.White;
		((Control)btnCancel).Location = new Point(1098, 654);
		((Control)btnCancel).Name = "btnCancel";
		((Control)btnCancel).Size = new Size(117, 33);
		((Control)btnCancel).TabIndex = 60;
		((Control)btnCancel).Text = "Cancel";
		((Control)btnCancel).Click += btnCancel_Click;
		btnSave.DisabledState.BorderColor = Color.DarkGray;
		btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
		btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
		btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
		btnSave.FillColor = Color.DodgerBlue;
		((Control)btnSave).Font = new Font("Bahnschrift SemiCondensed", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnSave).ForeColor = Color.White;
		((Control)btnSave).Location = new Point(975, 654);
		((Control)btnSave).Name = "btnSave";
		((Control)btnSave).Size = new Size(117, 33);
		((Control)btnSave).TabIndex = 59;
		((Control)btnSave).Text = "Save";
		((Control)btnSave).Click += btnSave_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(44, 46, 86);
		((Form)this).ClientSize = new Size(1255, 705);
		((Control)this).Controls.Add((Control)(object)btnCancel);
		((Control)this).Controls.Add((Control)(object)btnSave);
		((Control)this).Controls.Add((Control)(object)siticoneGroupBox5);
		((Control)this).Controls.Add((Control)(object)siticoneGroupBox4);
		((Control)this).Controls.Add((Control)(object)siticoneGroupBox3);
		((Control)this).Controls.Add((Control)(object)siticoneGroupBox2);
		((Control)this).Controls.Add((Control)(object)siticoneGroupBox1);
		((Control)this).Controls.Add((Control)(object)DragPanel);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = "frmSet";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "frmSet";
		((Control)DragPanel).ResumeLayout(false);
		((Control)DragPanel).PerformLayout();
		((ISupportInitialize)siticonePictureBox2).EndInit();
		((Control)siticoneGroupBox1).ResumeLayout(false);
		((Control)siticoneGroupBox1).PerformLayout();
		((Control)siticoneGroupBox2).ResumeLayout(false);
		((Control)siticoneGroupBox2).PerformLayout();
		((Control)siticoneGroupBox3).ResumeLayout(false);
		((Control)siticoneGroupBox3).PerformLayout();
		((Control)siticoneGroupBox4).ResumeLayout(false);
		((Control)siticoneGroupBox4).PerformLayout();
		((Control)siticoneGroupBox5).ResumeLayout(false);
		((Control)siticoneGroupBox5).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
