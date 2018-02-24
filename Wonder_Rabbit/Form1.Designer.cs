namespace Wonder_Rabbit
{
    partial class mainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftDock = new System.Windows.Forms.PictureBox();
            this.stateBox = new System.Windows.Forms.GroupBox();
            this.spdUp_Btn = new System.Windows.Forms.Button();
            this.spdDown_Btn = new System.Windows.Forms.Button();
            this.level_Label = new System.Windows.Forms.Label();
            this.score_Label = new System.Windows.Forms.Label();
            this.speed_Label = new System.Windows.Forms.Label();
            this.star_Label = new System.Windows.Forms.Label();
            this.life_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.manual_Btn = new System.Windows.Forms.Button();
            this.start_Btn = new System.Windows.Forms.Button();
            this.exit_Btn = new System.Windows.Forms.Button();
            this.rabbit_Pic = new System.Windows.Forms.PictureBox();
            this.cloud_Pic = new System.Windows.Forms.PictureBox();
            this.moving_timer = new System.Windows.Forms.Timer(this.components);
            this.score_timer = new System.Windows.Forms.Timer(this.components);
            this.mad_timer = new System.Windows.Forms.Timer(this.components);
            this.cloud_Timer = new System.Windows.Forms.Timer(this.components);
            this.Dfield = new Wonder_Rabbit.DoubleBufferPanel();
            this.game_over_Label = new System.Windows.Forms.Label();
            this.high_Btn = new System.Windows.Forms.Button();
            this.generateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.leftDock)).BeginInit();
            this.stateBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rabbit_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloud_Pic)).BeginInit();
            this.Dfield.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftDock
            // 
            this.leftDock.Image = global::Wonder_Rabbit.Properties.Resources.왼쪽;
            this.leftDock.Location = new System.Drawing.Point(0, 0);
            this.leftDock.Name = "leftDock";
            this.leftDock.Size = new System.Drawing.Size(200, 600);
            this.leftDock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftDock.TabIndex = 0;
            this.leftDock.TabStop = false;
            // 
            // stateBox
            // 
            this.stateBox.Controls.Add(this.spdUp_Btn);
            this.stateBox.Controls.Add(this.spdDown_Btn);
            this.stateBox.Controls.Add(this.level_Label);
            this.stateBox.Controls.Add(this.score_Label);
            this.stateBox.Controls.Add(this.speed_Label);
            this.stateBox.Controls.Add(this.star_Label);
            this.stateBox.Controls.Add(this.life_Label);
            this.stateBox.Controls.Add(this.label5);
            this.stateBox.Controls.Add(this.label4);
            this.stateBox.Controls.Add(this.label3);
            this.stateBox.Controls.Add(this.label2);
            this.stateBox.Controls.Add(this.label1);
            this.stateBox.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stateBox.Location = new System.Drawing.Point(12, 13);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(182, 255);
            this.stateBox.TabIndex = 2;
            this.stateBox.TabStop = false;
            this.stateBox.Text = "State Box";
            // 
            // spdUp_Btn
            // 
            this.spdUp_Btn.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdUp_Btn.Location = new System.Drawing.Point(148, 107);
            this.spdUp_Btn.Name = "spdUp_Btn";
            this.spdUp_Btn.Size = new System.Drawing.Size(23, 45);
            this.spdUp_Btn.TabIndex = 10;
            this.spdUp_Btn.Text = ">";
            this.spdUp_Btn.UseVisualStyleBackColor = true;
            this.spdUp_Btn.Click += new System.EventHandler(this.spdUp_Btn_Click);
            // 
            // spdDown_Btn
            // 
            this.spdDown_Btn.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdDown_Btn.Location = new System.Drawing.Point(122, 107);
            this.spdDown_Btn.Name = "spdDown_Btn";
            this.spdDown_Btn.Size = new System.Drawing.Size(23, 45);
            this.spdDown_Btn.TabIndex = 9;
            this.spdDown_Btn.Text = "<";
            this.spdDown_Btn.UseVisualStyleBackColor = true;
            this.spdDown_Btn.Click += new System.EventHandler(this.spdDown_Btn_Click);
            // 
            // level_Label
            // 
            this.level_Label.AutoSize = true;
            this.level_Label.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.level_Label.Location = new System.Drawing.Point(84, 214);
            this.level_Label.Name = "level_Label";
            this.level_Label.Size = new System.Drawing.Size(22, 25);
            this.level_Label.TabIndex = 8;
            this.level_Label.Text = "1";
            // 
            // score_Label
            // 
            this.score_Label.AutoSize = true;
            this.score_Label.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.score_Label.Location = new System.Drawing.Point(84, 170);
            this.score_Label.Name = "score_Label";
            this.score_Label.Size = new System.Drawing.Size(22, 25);
            this.score_Label.TabIndex = 7;
            this.score_Label.Text = "0";
            // 
            // speed_Label
            // 
            this.speed_Label.AutoSize = true;
            this.speed_Label.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.speed_Label.Location = new System.Drawing.Point(85, 121);
            this.speed_Label.Name = "speed_Label";
            this.speed_Label.Size = new System.Drawing.Size(32, 25);
            this.speed_Label.TabIndex = 6;
            this.speed_Label.Text = "25";
            // 
            // star_Label
            // 
            this.star_Label.AutoSize = true;
            this.star_Label.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.star_Label.Location = new System.Drawing.Point(65, 79);
            this.star_Label.Name = "star_Label";
            this.star_Label.Size = new System.Drawing.Size(22, 25);
            this.star_Label.TabIndex = 5;
            this.star_Label.Text = "2";
            // 
            // life_Label
            // 
            this.life_Label.AutoSize = true;
            this.life_Label.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.life_Label.Location = new System.Drawing.Point(54, 34);
            this.life_Label.Name = "life_Label";
            this.life_Label.Size = new System.Drawing.Size(32, 25);
            this.life_Label.TabIndex = 3;
            this.life_Label.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(5, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Level : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(5, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Score : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Star : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Life : ";
            // 
            // manual_Btn
            // 
            this.manual_Btn.Location = new System.Drawing.Point(13, 380);
            this.manual_Btn.Name = "manual_Btn";
            this.manual_Btn.Size = new System.Drawing.Size(181, 37);
            this.manual_Btn.TabIndex = 3;
            this.manual_Btn.Text = "Manual";
            this.manual_Btn.UseVisualStyleBackColor = true;
            this.manual_Btn.Click += new System.EventHandler(this.manual_Btn_Click);
            // 
            // start_Btn
            // 
            this.start_Btn.Location = new System.Drawing.Point(13, 423);
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.Size = new System.Drawing.Size(181, 37);
            this.start_Btn.TabIndex = 4;
            this.start_Btn.Text = "Start";
            this.start_Btn.UseVisualStyleBackColor = true;
            this.start_Btn.Click += new System.EventHandler(this.start_Btn_Click);
            // 
            // exit_Btn
            // 
            this.exit_Btn.Location = new System.Drawing.Point(12, 466);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(181, 37);
            this.exit_Btn.TabIndex = 5;
            this.exit_Btn.Text = "Exit";
            this.exit_Btn.UseVisualStyleBackColor = true;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // rabbit_Pic
            // 
            this.rabbit_Pic.Image = global::Wonder_Rabbit.Properties.Resources.토끼;
            this.rabbit_Pic.Location = new System.Drawing.Point(0, 440);
            this.rabbit_Pic.Name = "rabbit_Pic";
            this.rabbit_Pic.Size = new System.Drawing.Size(52, 82);
            this.rabbit_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rabbit_Pic.TabIndex = 6;
            this.rabbit_Pic.TabStop = false;
            // 
            // cloud_Pic
            // 
            this.cloud_Pic.BackColor = System.Drawing.Color.Transparent;
            this.cloud_Pic.Image = global::Wonder_Rabbit.Properties.Resources.구름;
            this.cloud_Pic.Location = new System.Drawing.Point(300, 30);
            this.cloud_Pic.Name = "cloud_Pic";
            this.cloud_Pic.Size = new System.Drawing.Size(80, 60);
            this.cloud_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloud_Pic.TabIndex = 7;
            this.cloud_Pic.TabStop = false;
            // 
            // moving_timer
            // 
            this.moving_timer.Interval = 1;
            this.moving_timer.Tick += new System.EventHandler(this.moving_timer_Tick);
            // 
            // score_timer
            // 
            this.score_timer.Tick += new System.EventHandler(this.score_timer_Tick);
            // 
            // mad_timer
            // 
            this.mad_timer.Interval = 3000;
            this.mad_timer.Tick += new System.EventHandler(this.mad_timer_Tick);
            // 
            // cloud_Timer
            // 
            this.cloud_Timer.Interval = 10;
            this.cloud_Timer.Tick += new System.EventHandler(this.cloud_Timer_Tick);
            // 
            // Dfield
            // 
            this.Dfield.BackgroundImage = global::Wonder_Rabbit.Properties.Resources.초원;
            this.Dfield.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dfield.Controls.Add(this.game_over_Label);
            this.Dfield.Location = new System.Drawing.Point(200, 0);
            this.Dfield.Name = "Dfield";
            this.Dfield.Size = new System.Drawing.Size(600, 600);
            this.Dfield.TabIndex = 0;
            // 
            // game_over_Label
            // 
            this.game_over_Label.AutoSize = true;
            this.game_over_Label.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.game_over_Label.Location = new System.Drawing.Point(203, 164);
            this.game_over_Label.Name = "game_over_Label";
            this.game_over_Label.Size = new System.Drawing.Size(160, 28);
            this.game_over_Label.TabIndex = 0;
            this.game_over_Label.Text = "Game Over";
            // 
            // high_Btn
            // 
            this.high_Btn.Location = new System.Drawing.Point(13, 305);
            this.high_Btn.Name = "high_Btn";
            this.high_Btn.Size = new System.Drawing.Size(181, 59);
            this.high_Btn.TabIndex = 8;
            this.high_Btn.Text = "High Score";
            this.high_Btn.UseVisualStyleBackColor = true;
            this.high_Btn.Click += new System.EventHandler(this.high_Btn_Click);
            // 
            // generateTimer
            // 
            this.generateTimer.Interval = 200;
            this.generateTimer.Tick += new System.EventHandler(this.generateTimer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 603);
            this.Controls.Add(this.high_Btn);
            this.Controls.Add(this.cloud_Pic);
            this.Controls.Add(this.rabbit_Pic);
            this.Controls.Add(this.exit_Btn);
            this.Controls.Add(this.start_Btn);
            this.Controls.Add(this.manual_Btn);
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.leftDock);
            this.Controls.Add(this.Dfield);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wonder Rabbit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            ((System.ComponentModel.ISupportInitialize)(this.leftDock)).EndInit();
            this.stateBox.ResumeLayout(false);
            this.stateBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rabbit_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloud_Pic)).EndInit();
            this.Dfield.ResumeLayout(false);
            this.Dfield.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftDock;
        private System.Windows.Forms.GroupBox stateBox;
        private System.Windows.Forms.Label life_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button spdUp_Btn;
        private System.Windows.Forms.Button spdDown_Btn;
        private System.Windows.Forms.Label level_Label;
        private System.Windows.Forms.Label score_Label;
        private System.Windows.Forms.Label speed_Label;
        private System.Windows.Forms.Label star_Label;
        private System.Windows.Forms.Button manual_Btn;
        private System.Windows.Forms.Button start_Btn;
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.PictureBox rabbit_Pic;
        private System.Windows.Forms.PictureBox cloud_Pic;
        private System.Windows.Forms.Timer moving_timer;
        private DoubleBufferPanel Dfield;
        private System.Windows.Forms.Timer score_timer;
        private System.Windows.Forms.Label game_over_Label;
        private System.Windows.Forms.Timer mad_timer;
        private System.Windows.Forms.Timer cloud_Timer;
        private System.Windows.Forms.Button high_Btn;
        private System.Windows.Forms.Timer generateTimer;
    }
}

