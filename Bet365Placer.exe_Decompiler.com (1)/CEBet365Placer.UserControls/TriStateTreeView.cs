using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CEBet365Placer.UserControls;

public class TriStateTreeView : TreeView
{
	private ImageList _ilStateImages;

	private bool _bUseTriState;

	private bool _bCheckBoxesVisible;

	private bool _bPreventCheckEvent;

	[Category("Appearance")]
	[Description("Sets tree view to display checkboxes or not.")]
	[DefaultValue(false)]
	public bool CheckBoxes
	{
		get
		{
			return _bCheckBoxesVisible;
		}
		set
		{
			_bCheckBoxesVisible = value;
			((TreeView)this).CheckBoxes = _bCheckBoxesVisible;
			StateImageList = (_bCheckBoxesVisible ? _ilStateImages : null);
		}
	}

	[Browsable(false)]
	public ImageList StateImageList
	{
		get
		{
			return ((TreeView)this).StateImageList;
		}
		set
		{
			((TreeView)this).StateImageList = value;
		}
	}

	[Category("Appearance")]
	[Description("Sets tree view to use tri-state checkboxes or not.")]
	[DefaultValue(true)]
	public bool CheckBoxesTriState
	{
		get
		{
			return _bUseTriState;
		}
		set
		{
			_bUseTriState = value;
		}
	}

	public TriStateTreeView()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		_ilStateImages = new ImageList();
		CheckBoxState val = (CheckBoxState)1;
		for (int i = 0; i <= 2; i++)
		{
			Bitmap val2 = new Bitmap(16, 16);
			Graphics val3 = Graphics.FromImage((Image)(object)val2);
			switch (i)
			{
			case 0:
				val = (CheckBoxState)1;
				break;
			case 1:
				val = (CheckBoxState)5;
				break;
			case 2:
				val = (CheckBoxState)9;
				break;
			}
			CheckBoxRenderer.DrawCheckBox(val3, new Point(2, 2), val);
			val3.Save();
			_ilStateImages.Images.Add((Image)(object)val2);
			_bUseTriState = true;
		}
	}

	public override void Refresh()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((Control)this).Refresh();
		if (!CheckBoxes)
		{
			return;
		}
		((TreeView)this).CheckBoxes = false;
		Stack<TreeNode> stack = new Stack<TreeNode>(((TreeView)this).Nodes.Count);
		foreach (TreeNode node in ((TreeView)this).Nodes)
		{
			TreeNode item = node;
			stack.Push(item);
		}
		while (stack.Count > 0)
		{
			TreeNode val = stack.Pop();
			if (val.StateImageIndex == -1)
			{
				val.StateImageIndex = (val.Checked ? 1 : 0);
			}
			for (int i = 0; i < val.Nodes.Count; i++)
			{
				stack.Push(val.Nodes[i]);
			}
		}
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		((Control)this).OnLayout(levent);
		((Control)this).Refresh();
	}

	protected override void OnAfterExpand(TreeViewEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		((TreeView)this).OnAfterExpand(e);
		foreach (TreeNode node in e.Node.Nodes)
		{
			TreeNode val = node;
			if (val.StateImageIndex == -1)
			{
				val.StateImageIndex = (val.Checked ? 1 : 0);
			}
		}
	}

	protected override void OnAfterCheck(TreeViewEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		((TreeView)this).OnAfterCheck(e);
		if (!_bPreventCheckEvent)
		{
			((TreeView)this).OnNodeMouseClick(new TreeNodeMouseClickEventArgs(e.Node, (MouseButtons)0, 0, 0, 0));
		}
	}

	protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		((TreeView)this).OnNodeMouseClick(e);
		_bPreventCheckEvent = true;
		int num = ((((TreeView)this).ImageList != null) ? 18 : 0);
		if ((((MouseEventArgs)e).X > e.Node.Bounds.Left - num || ((MouseEventArgs)e).X < e.Node.Bounds.Left - (num + 16)) && (int)((MouseEventArgs)e).Button != 0)
		{
			return;
		}
		TreeNode node = e.Node;
		if ((int)((MouseEventArgs)e).Button == 1048576)
		{
			node.Checked = !node.Checked;
		}
		node.StateImageIndex = (node.Checked ? 1 : node.StateImageIndex);
		((TreeView)this).OnAfterCheck(new TreeViewEventArgs(node, (TreeViewAction)2));
		Stack<TreeNode> stack = new Stack<TreeNode>(node.Nodes.Count);
		stack.Push(node);
		do
		{
			node = stack.Pop();
			node.Checked = e.Node.Checked;
			for (int i = 0; i < node.Nodes.Count; i++)
			{
				stack.Push(node.Nodes[i]);
			}
		}
		while (stack.Count > 0);
		bool flag = false;
		node = e.Node;
		while (node.Parent != null)
		{
			foreach (TreeNode node2 in node.Parent.Nodes)
			{
				TreeNode val = node2;
				flag |= (val.Checked != node.Checked) | (val.StateImageIndex == 2);
			}
			int num2 = (int)Convert.ToUInt32(node.Checked);
			node.Parent.Checked = flag || num2 > 0;
			if (flag)
			{
				node.Parent.StateImageIndex = ((!CheckBoxesTriState) ? 1 : 2);
			}
			else
			{
				node.Parent.StateImageIndex = num2;
			}
			node = node.Parent;
		}
		_bPreventCheckEvent = false;
	}
}
