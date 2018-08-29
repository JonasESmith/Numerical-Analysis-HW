namespace BisectionMethod
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.functionLabel = new System.Windows.Forms.Label();
      this.functionTextBox = new System.Windows.Forms.TextBox();
      this.iterationLabel = new System.Windows.Forms.Label();
      this.iterationTextBox = new System.Windows.Forms.TextBox();
      this.domainLabel = new System.Windows.Forms.Label();
      this.domainTextBox = new System.Windows.Forms.TextBox();
      this.comptueButton = new System.Windows.Forms.Button();
      this.infoPanel = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // functionLabel
      // 
      this.functionLabel.AutoSize = true;
      this.functionLabel.Location = new System.Drawing.Point(12, 9);
      this.functionLabel.Name = "functionLabel";
      this.functionLabel.Size = new System.Drawing.Size(27, 13);
      this.functionLabel.TabIndex = 0;
      this.functionLabel.Text = "f(x) :";
      // 
      // functionTextBox
      // 
      this.functionTextBox.Location = new System.Drawing.Point(67, 6);
      this.functionTextBox.Name = "functionTextBox";
      this.functionTextBox.Size = new System.Drawing.Size(264, 20);
      this.functionTextBox.TabIndex = 1;
      // 
      // iterationLabel
      // 
      this.iterationLabel.AutoSize = true;
      this.iterationLabel.Location = new System.Drawing.Point(12, 41);
      this.iterationLabel.Name = "iterationLabel";
      this.iterationLabel.Size = new System.Drawing.Size(49, 13);
      this.iterationLabel.TabIndex = 2;
      this.iterationLabel.Text = "iterations";
      // 
      // iterationTextBox
      // 
      this.iterationTextBox.Location = new System.Drawing.Point(67, 38);
      this.iterationTextBox.Name = "iterationTextBox";
      this.iterationTextBox.Size = new System.Drawing.Size(60, 20);
      this.iterationTextBox.TabIndex = 3;
      // 
      // domainLabel
      // 
      this.domainLabel.AutoSize = true;
      this.domainLabel.Location = new System.Drawing.Point(133, 41);
      this.domainLabel.Name = "domainLabel";
      this.domainLabel.Size = new System.Drawing.Size(43, 13);
      this.domainLabel.TabIndex = 4;
      this.domainLabel.Text = "Domain";
      // 
      // domainTextBox
      // 
      this.domainTextBox.Location = new System.Drawing.Point(183, 41);
      this.domainTextBox.Name = "domainTextBox";
      this.domainTextBox.Size = new System.Drawing.Size(148, 20);
      this.domainTextBox.TabIndex = 5;
      // 
      // comptueButton
      // 
      this.comptueButton.Location = new System.Drawing.Point(346, 9);
      this.comptueButton.Name = "comptueButton";
      this.comptueButton.Size = new System.Drawing.Size(57, 49);
      this.comptueButton.TabIndex = 6;
      this.comptueButton.Text = "Compute";
      this.comptueButton.UseVisualStyleBackColor = true;
      this.comptueButton.Click += new System.EventHandler(this.comptueButton_Click);
      // 
      // infoPanel
      // 
      this.infoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.infoPanel.Location = new System.Drawing.Point(0, 78);
      this.infoPanel.Name = "infoPanel";
      this.infoPanel.Size = new System.Drawing.Size(416, 263);
      this.infoPanel.TabIndex = 7;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(416, 341);
      this.Controls.Add(this.infoPanel);
      this.Controls.Add(this.comptueButton);
      this.Controls.Add(this.domainTextBox);
      this.Controls.Add(this.domainLabel);
      this.Controls.Add(this.iterationTextBox);
      this.Controls.Add(this.iterationLabel);
      this.Controls.Add(this.functionTextBox);
      this.Controls.Add(this.functionLabel);
      this.Name = "MainForm";
      this.Text = "Bisection Method";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label functionLabel;
    private System.Windows.Forms.TextBox functionTextBox;
    private System.Windows.Forms.Label iterationLabel;
    private System.Windows.Forms.TextBox iterationTextBox;
    private System.Windows.Forms.Label domainLabel;
    private System.Windows.Forms.TextBox domainTextBox;
    private System.Windows.Forms.Button comptueButton;
    private System.Windows.Forms.Panel infoPanel;
  }
}

