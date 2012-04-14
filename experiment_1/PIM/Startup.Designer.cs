namespace Outlook_1.Gui
{
	partial class Startup
	{
		/// <summary>
/// Required designer variable.
/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;
		/// <summary>
		/// Clean up any resources being used.
/// </summary>
/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}
#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
/// </summary>
		private void InitializeComponent ()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu ();
			this.menuMain = new System.Windows.Forms.MenuItem ();
			this.menuItemGpsMenu = new System.Windows.Forms.MenuItem ();
			this.menuItemGpsOn = new System.Windows.Forms.MenuItem ();
			this.menuItemGpsOff = new System.Windows.Forms.MenuItem ();
			this.menuItem2 = new System.Windows.Forms.MenuItem ();
			this.menuItem3 = new System.Windows.Forms.MenuItem ();
			this.menuItem4 = new System.Windows.Forms.MenuItem ();
			this.menuItem1 = new System.Windows.Forms.MenuItem ();
			this.menuItemExit = new System.Windows.Forms.MenuItem ();
			this.lblHeader = new System.Windows.Forms.Label ();
			this.lblSocial = new System.Windows.Forms.Label ();
			this.lblSetZone = new System.Windows.Forms.Label ();
			this.btnRefresh = new System.Windows.Forms.Button ();
			this.lblZone = new System.Windows.Forms.Label ();
			this.lblSetSocial = new System.Windows.Forms.Label ();
			this.lblGps = new System.Windows.Forms.Label ();
			this.lblSetGps = new System.Windows.Forms.Label ();
			this.txtStatus = new System.Windows.Forms.TextBox ();
			this.SuspendLayout ();
// 
// mainMenu1
// 
			this.mainMenu1.MenuItems.Add (this.menuMain);
			this.mainMenu1.MenuItems.Add (this.menuItemExit);
// 
// menuMain
			this.menuMain.MenuItems.Add (this.menuItemGpsMenu);
			this.menuMain.MenuItems.Add (this.menuItem2);
			this.menuMain.MenuItems.Add (this.menuItem1);
			this.menuMain.Text = "Menu";
			this.menuMain.Click += new 
System.EventHandler (this.menuMain_Click);
//
			// menuItemGpsMenu
// 
			this.menuItemGpsMenu.MenuItems.Add (this.menuItemGpsOn);
			this.menuItemGpsMenu.MenuItems.Add (this.menuItemGpsOff);
			this.menuItemGpsMenu.Text = "GPS";
			this.menuItemGpsMenu.Click += new 
System.EventHandler (this.menuItemGpsMenu_Click);
			// 
// menuItemGpsOn
// 
			this.menuItemGpsOn.Text = "GPS On";
			this.menuItemGpsOn.Click += new 
System.EventHandler (this.menuItemGpsOn_Click);
// 
// menuItemGpsOff
// 
			this.menuItemGpsOff.Text = "GPS Off";
			this.menuItemGpsOff.Click += new 
System.EventHandler (this.menuItemGpsOff_Click);
// 
// menuItem2
// 
			this.menuItem2.MenuItems.Add (this.menuItem3);
			this.menuItem2.MenuItems.Add (this.menuItem4);
			this.menuItem2.Text = "Status";
// 
// menuItem3
// 
			this.menuItem3.Text = "Current Appointment";
			this.menuItem3.Click += new 
System.EventHandler (this.menuItem3_Click);
			// 
// menuItem4
// 
			this.menuItem4.Text = "Next Appointment";
			this.menuItem4.Click += new 
System.EventHandler (this.menuItem4_Click);
			// 
// menuItem1
// 
			this.menuItem1.Text = "About";
			this.menuItem1.Click += new 
System.EventHandler (this.menuItem1_Click);
// 
// menuItemExit
// 
			this.menuItemExit.Text = "Exit";
			this.menuItemExit.Click += new 
System.EventHandler (this.menuItemExit_Click);
			// 
// lblHeader
// 
			this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblHeader.Font = new System.Drawing.Font ("Tahoma", 12F, 
System.Drawing.FontStyle.Regular);
			this.lblHeader.Location = new System.Drawing.Point (0, 0);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size (240, 20);
			this.lblHeader.Text = "PIM Application Beta ";
			this.lblHeader.TextAlign = 
System.Drawing.ContentAlignment.TopCenter;
			this.lblHeader.ParentChanged += new 
System.EventHandler (this.lblHeader_ParentChanged);
			// 
// lblSocial
// 
			this.lblSocial.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblSocial.Font = new System.Drawing.Font ("Tahoma", 10F, 
System.Drawing.FontStyle.Regular);
			this.lblSocial.Location = new System.Drawing.Point (3, 222);
			this.lblSocial.Name = "lblSocial";
			this.lblSocial.Size = new System.Drawing.Size (120, 20);
			this.lblSocial.Text = "Current Social";
// 
// lblSetZone
// 
			this.lblSetZone.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblSetZone.Font = new System.Drawing.Font ("Tahoma", 10F, 
System.Drawing.FontStyle.Regular);
			this.lblSetZone.Location = new System.Drawing.Point (123, 
202);
			this.lblSetZone.Name = "lblSetZone";
			this.lblSetZone.Size = new System.Drawing.Size (113, 20);
// 
// btnRefresh
// 
			this.btnRefresh.Location = new System.Drawing.Point (3, 245);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size (151, 20);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Reset display text";
			this.btnRefresh.Click += new 
System.EventHandler (this.btnRefresh_Click);
// 
// lblZone
// 
			this.lblZone.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblZone.Font = new System.Drawing.Font ("Tahoma", 10F, 
System.Drawing.FontStyle.Regular);
			this.lblZone.Location = new System.Drawing.Point (3, 202);
			this.lblZone.Name = "lblZone";
			this.lblZone.Size = new System.Drawing.Size (120, 20);
			this.lblZone.Text = "Current Zone";
// 
			// lblSetSocial
			// 
			this.lblSetSocial.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblSetSocial.Font = new System.Drawing.Font ("Tahoma", 
10F, System.Drawing.FontStyle.Regular);
			this.lblSetSocial.Location = new System.Drawing.Point (123, 
222);
			this.lblSetSocial.Name = "lblSetSocial";
			this.lblSetSocial.Size = new System.Drawing.Size (113, 20);
// 
// lblGps
// 
			this.lblGps.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblGps.Font = new System.Drawing.Font ("Tahoma", 10F, 
System.Drawing.FontStyle.Regular);
			this.lblGps.Location = new System.Drawing.Point (3, 182);
			this.lblGps.Name = "lblGps";
			this.lblGps.Size = new System.Drawing.Size (80, 20);
			this.lblGps.Text = "GPS status";
			// 
			// lblSetGps
// 
			this.lblSetGps.BackColor = 
System.Drawing.Color.FromArgb (((int)(((byte)(224)))), 
((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblSetGps.Font = new System.Drawing.Font ("Tahoma", 10F, 
System.Drawing.FontStyle.Regular);
			this.lblSetGps.Location = new System.Drawing.Point (78, 182);
			this.lblSetGps.Name = "lblSetGps";
			this.lblSetGps.Size = new System.Drawing.Size (158, 20);
// 
			// txtStatus
			// 
			this.txtStatus.BorderStyle = 
System.Windows.Forms.BorderStyle.None;
			this.txtStatus.Location = new System.Drawing.Point (3, 23);
			this.txtStatus.Multiline = true;
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ScrollBars = 
System.Windows.Forms.ScrollBars.Vertical;
			this.txtStatus.Size = new System.Drawing.Size (233, 153);
			this.txtStatus.TabIndex = 20;
// 
// Startup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (96F, 
96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size (240, 268);
			this.Controls.Add (this.txtStatus);
			this.Controls.Add (this.btnRefresh);
			this.Controls.Add (this.lblSetSocial);
			this.Controls.Add (this.lblSetGps);
			this.Controls.Add (this.lblSetZone);
			this.Controls.Add (this.lblGps);
			this.Controls.Add (this.lblZone);
			this.Controls.Add (this.lblSocial);
			this.Controls.Add (this.lblHeader);
			this.Menu = this.mainMenu1;
			this.Name = "Startup";
			this.Text = "MTech Dissertation";
			this.Load += new System.EventHandler (this.Startup_Load);
			this.ResumeLayout (false);
		}
#endregion
		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.MenuItem menuMain;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.Label lblSocial;
		private System.Windows.Forms.Label lblSetZone;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label lblZone;
		private System.Windows.Forms.Label lblSetSocial;
		private System.Windows.Forms.MenuItem menuItemGpsMenu;
		private System.Windows.Forms.MenuItem menuItemGpsOn;
		private System.Windows.Forms.MenuItem menuItemGpsOff;
		private System.Windows.Forms.Label lblGps;
		private System.Windows.Forms.Label lblSetGps;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
	}
}