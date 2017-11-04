namespace PipeHttpRuner
{
    partial class PipeHttpRuner
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeHttpRuner));
            this.lb_pipeHost = new System.Windows.Forms.Label();
            this.lv_pipeList = new System.Windows.Forms.ListView();
            this.columnHeader_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_reConectCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_forPipeList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_reConTime = new System.Windows.Forms.Label();
            this.lb_responseType = new System.Windows.Forms.Label();
            this.cb_responseType = new System.Windows.Forms.ComboBox();
            this.bt_addPile = new System.Windows.Forms.Button();
            this.bt_sendRequest = new System.Windows.Forms.Button();
            this.cb_isAsynSend = new System.Windows.Forms.CheckBox();
            this.lb_requestCount = new System.Windows.Forms.Label();
            this.bt_connectAllPile = new System.Windows.Forms.Button();
            this.tb_rawRequest = new System.Windows.Forms.TextBox();
            this.pb_editRawRequest = new System.Windows.Forms.PictureBox();
            this.rtb_dataRecieve = new MyCommonControl.DataRecordBox();
            this.tb_RequstCount = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_addTime = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_reConTime = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_pilePort = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_pileHost = new MyCommonControl.Control.TextBoxWithWatermak();
            this.panel_editRequest = new System.Windows.Forms.Panel();
            this.pb_editRequestDelHaeds = new System.Windows.Forms.PictureBox();
            this.pb_editRequestCancel = new System.Windows.Forms.PictureBox();
            this.pb_editRequestComfrim = new System.Windows.Forms.PictureBox();
            this.tb_editRequestBody = new MyCommonControl.Control.TextBoxWithWatermak();
            this.lb_editHeads = new System.Windows.Forms.Label();
            this.tb_editHeadVaule = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_editHeadKey = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_editSartLine = new MyCommonControl.Control.TextBoxWithWatermak();
            this.bt_editAddHead = new System.Windows.Forms.Button();
            this.lv_editRequestHeads = new System.Windows.Forms.ListView();
            this.columnHeader_heads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_editRequestEdition = new System.Windows.Forms.ComboBox();
            this.cb_editRequestMethod = new System.Windows.Forms.ComboBox();
            this.lb_editStartLine = new System.Windows.Forms.Label();
            this.ck_saveResponse = new System.Windows.Forms.CheckBox();
            this.panel_addPipe = new System.Windows.Forms.Panel();
            this.pb_saveResponseStream = new System.Windows.Forms.PictureBox();
            this.lb_getResponseState = new System.Windows.Forms.Label();
            this.contextMenuStrip_forPipeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRawRequest)).BeginInit();
            this.panel_editRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestDelHaeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestComfrim)).BeginInit();
            this.panel_addPipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_saveResponseStream)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_pipeHost
            // 
            this.lb_pipeHost.AutoSize = true;
            this.lb_pipeHost.Location = new System.Drawing.Point(1, 322);
            this.lb_pipeHost.Name = "lb_pipeHost";
            this.lb_pipeHost.Size = new System.Drawing.Size(65, 12);
            this.lb_pipeHost.TabIndex = 4;
            this.lb_pipeHost.Text = "pipe host:";
            // 
            // lv_pipeList
            // 
            this.lv_pipeList.BackColor = System.Drawing.Color.AliceBlue;
            this.lv_pipeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_id,
            this.columnHeader_reConectCount});
            this.lv_pipeList.ContextMenuStrip = this.contextMenuStrip_forPipeList;
            this.lv_pipeList.FullRowSelect = true;
            this.lv_pipeList.Location = new System.Drawing.Point(821, 3);
            this.lv_pipeList.Name = "lv_pipeList";
            this.lv_pipeList.Size = new System.Drawing.Size(139, 520);
            this.lv_pipeList.TabIndex = 5;
            this.lv_pipeList.UseCompatibleStateImageBehavior = false;
            this.lv_pipeList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_id
            // 
            this.columnHeader_id.Text = "ID";
            this.columnHeader_id.Width = 34;
            // 
            // columnHeader_reConectCount
            // 
            this.columnHeader_reConectCount.Text = "reConectCount";
            this.columnHeader_reConectCount.Width = 97;
            // 
            // contextMenuStrip_forPipeList
            // 
            this.contextMenuStrip_forPipeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeThisToolStripMenuItem,
            this.removeAllToolStripMenuItem,
            this.reconnectThisToolStripMenuItem,
            this.reconnectAllToolStripMenuItem});
            this.contextMenuStrip_forPipeList.Name = "contextMenuStrip_forPipeList";
            this.contextMenuStrip_forPipeList.Size = new System.Drawing.Size(161, 92);
            // 
            // removeThisToolStripMenuItem
            // 
            this.removeThisToolStripMenuItem.Name = "removeThisToolStripMenuItem";
            this.removeThisToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.removeThisToolStripMenuItem.Text = "Remove this";
            this.removeThisToolStripMenuItem.Click += new System.EventHandler(this.removeThisToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.removeAllToolStripMenuItem.Text = "Remove all";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // reconnectThisToolStripMenuItem
            // 
            this.reconnectThisToolStripMenuItem.Name = "reconnectThisToolStripMenuItem";
            this.reconnectThisToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.reconnectThisToolStripMenuItem.Text = "Reconnect this";
            this.reconnectThisToolStripMenuItem.Click += new System.EventHandler(this.reconnectThisToolStripMenuItem_Click);
            // 
            // reconnectAllToolStripMenuItem
            // 
            this.reconnectAllToolStripMenuItem.Name = "reconnectAllToolStripMenuItem";
            this.reconnectAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.reconnectAllToolStripMenuItem.Text = "Reconnect all";
            this.reconnectAllToolStripMenuItem.Click += new System.EventHandler(this.reconnectAllToolStripMenuItem_Click);
            // 
            // lb_reConTime
            // 
            this.lb_reConTime.AutoSize = true;
            this.lb_reConTime.Location = new System.Drawing.Point(5, 7);
            this.lb_reConTime.Name = "lb_reConTime";
            this.lb_reConTime.Size = new System.Drawing.Size(65, 12);
            this.lb_reConTime.TabIndex = 7;
            this.lb_reConTime.Text = "ReConTime:";
            // 
            // lb_responseType
            // 
            this.lb_responseType.AutoSize = true;
            this.lb_responseType.Location = new System.Drawing.Point(5, 37);
            this.lb_responseType.Name = "lb_responseType";
            this.lb_responseType.Size = new System.Drawing.Size(59, 12);
            this.lb_responseType.TabIndex = 8;
            this.lb_responseType.Text = "Response:";
            // 
            // cb_responseType
            // 
            this.cb_responseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_responseType.FormattingEnabled = true;
            this.cb_responseType.Items.AddRange(new object[] {
            "Report",
            "Drop"});
            this.cb_responseType.Location = new System.Drawing.Point(71, 33);
            this.cb_responseType.Name = "cb_responseType";
            this.cb_responseType.Size = new System.Drawing.Size(129, 20);
            this.cb_responseType.TabIndex = 9;
            // 
            // bt_addPile
            // 
            this.bt_addPile.Location = new System.Drawing.Point(85, 65);
            this.bt_addPile.Name = "bt_addPile";
            this.bt_addPile.Size = new System.Drawing.Size(115, 23);
            this.bt_addPile.TabIndex = 11;
            this.bt_addPile.Text = "Add Pipe";
            this.bt_addPile.UseVisualStyleBackColor = true;
            this.bt_addPile.Click += new System.EventHandler(this.bt_addPile_Click);
            // 
            // bt_sendRequest
            // 
            this.bt_sendRequest.Location = new System.Drawing.Point(85, 154);
            this.bt_sendRequest.Name = "bt_sendRequest";
            this.bt_sendRequest.Size = new System.Drawing.Size(115, 23);
            this.bt_sendRequest.TabIndex = 12;
            this.bt_sendRequest.Text = "Send Request";
            this.bt_sendRequest.UseVisualStyleBackColor = true;
            this.bt_sendRequest.Click += new System.EventHandler(this.bt_sendRequest_Click);
            // 
            // cb_isAsynSend
            // 
            this.cb_isAsynSend.AutoSize = true;
            this.cb_isAsynSend.Location = new System.Drawing.Point(2, 158);
            this.cb_isAsynSend.Name = "cb_isAsynSend";
            this.cb_isAsynSend.Size = new System.Drawing.Size(84, 16);
            this.cb_isAsynSend.TabIndex = 13;
            this.cb_isAsynSend.Text = "isAsynSend";
            this.cb_isAsynSend.UseVisualStyleBackColor = true;
            // 
            // lb_requestCount
            // 
            this.lb_requestCount.AutoSize = true;
            this.lb_requestCount.Location = new System.Drawing.Point(5, 129);
            this.lb_requestCount.Name = "lb_requestCount";
            this.lb_requestCount.Size = new System.Drawing.Size(77, 12);
            this.lb_requestCount.TabIndex = 15;
            this.lb_requestCount.Text = "RequstCount:";
            // 
            // bt_connectAllPile
            // 
            this.bt_connectAllPile.Location = new System.Drawing.Point(85, 94);
            this.bt_connectAllPile.Name = "bt_connectAllPile";
            this.bt_connectAllPile.Size = new System.Drawing.Size(115, 23);
            this.bt_connectAllPile.TabIndex = 16;
            this.bt_connectAllPile.Text = "ConnectAllPile";
            this.bt_connectAllPile.UseVisualStyleBackColor = true;
            this.bt_connectAllPile.Click += new System.EventHandler(this.bt_connectAllPile_Click);
            // 
            // tb_rawRequest
            // 
            this.tb_rawRequest.BackColor = System.Drawing.Color.Azure;
            this.tb_rawRequest.Location = new System.Drawing.Point(3, 342);
            this.tb_rawRequest.Multiline = true;
            this.tb_rawRequest.Name = "tb_rawRequest";
            this.tb_rawRequest.Size = new System.Drawing.Size(611, 181);
            this.tb_rawRequest.TabIndex = 1;
            this.tb_rawRequest.Text = "GET http://www.baidu.com HTTP/1.1\r\nContent-Type: application/x-www-form-urlencode" +
    "d\r\nHost: www.baidu.com\r\nConnection: Keep-Alive\r\n\r\n";
            this.tb_rawRequest.Leave += new System.EventHandler(this.tb_rawRequest_Leave);
            // 
            // pb_editRawRequest
            // 
            this.pb_editRawRequest.BackColor = System.Drawing.Color.Transparent;
            this.pb_editRawRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editRawRequest.Image = ((System.Drawing.Image)(resources.GetObject("pb_editRawRequest.Image")));
            this.pb_editRawRequest.Location = new System.Drawing.Point(590, 343);
            this.pb_editRawRequest.Name = "pb_editRawRequest";
            this.pb_editRawRequest.Size = new System.Drawing.Size(23, 22);
            this.pb_editRawRequest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editRawRequest.TabIndex = 37;
            this.pb_editRawRequest.TabStop = false;
            this.pb_editRawRequest.Click += new System.EventHandler(this.pb_editRawRequest_Click);
            this.pb_editRawRequest.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_editRawRequest.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // rtb_dataRecieve
            // 
            this.rtb_dataRecieve.CanFill = true;
            this.rtb_dataRecieve.IsShowIcon = true;
            this.rtb_dataRecieve.Location = new System.Drawing.Point(3, 3);
            this.rtb_dataRecieve.MaxLine = 5000;
            this.rtb_dataRecieve.MianDirectory = "DataRecord";
            this.rtb_dataRecieve.Name = "rtb_dataRecieve";
            this.rtb_dataRecieve.Size = new System.Drawing.Size(815, 311);
            this.rtb_dataRecieve.TabIndex = 1;
            // 
            // tb_RequstCount
            // 
            this.tb_RequstCount.Location = new System.Drawing.Point(85, 125);
            this.tb_RequstCount.Name = "tb_RequstCount";
            this.tb_RequstCount.Size = new System.Drawing.Size(115, 21);
            this.tb_RequstCount.TabIndex = 14;
            this.tb_RequstCount.Text = "1";
            this.tb_RequstCount.WatermarkText = "RequstCount/pipe";
            // 
            // tb_addTime
            // 
            this.tb_addTime.Location = new System.Drawing.Point(2, 66);
            this.tb_addTime.Name = "tb_addTime";
            this.tb_addTime.Size = new System.Drawing.Size(77, 21);
            this.tb_addTime.TabIndex = 10;
            this.tb_addTime.Text = "1";
            this.tb_addTime.WatermarkText = "add time";
            // 
            // tb_reConTime
            // 
            this.tb_reConTime.Location = new System.Drawing.Point(70, 4);
            this.tb_reConTime.Name = "tb_reConTime";
            this.tb_reConTime.Size = new System.Drawing.Size(130, 21);
            this.tb_reConTime.TabIndex = 6;
            this.tb_reConTime.Text = "0";
            this.tb_reConTime.WatermarkText = "0 is never reconnect";
            // 
            // tb_pilePort
            // 
            this.tb_pilePort.Location = new System.Drawing.Point(349, 318);
            this.tb_pilePort.Name = "tb_pilePort";
            this.tb_pilePort.Size = new System.Drawing.Size(61, 21);
            this.tb_pilePort.TabIndex = 3;
            this.tb_pilePort.Text = "80";
            this.tb_pilePort.WatermarkText = "pipe port";
            this.tb_pilePort.TextChanged += new System.EventHandler(this.tb_pilePort_TextChanged);
            // 
            // tb_pileHost
            // 
            this.tb_pileHost.Location = new System.Drawing.Point(73, 318);
            this.tb_pileHost.Name = "tb_pileHost";
            this.tb_pileHost.Size = new System.Drawing.Size(260, 21);
            this.tb_pileHost.TabIndex = 2;
            this.tb_pileHost.Text = "www.baidu.com";
            this.tb_pileHost.WatermarkText = "pipe adress ip or host";
            this.tb_pileHost.TextChanged += new System.EventHandler(this.tb_pileHost_TextChanged);
            // 
            // panel_editRequest
            // 
            this.panel_editRequest.BackColor = System.Drawing.Color.Lavender;
            this.panel_editRequest.Controls.Add(this.pb_editRequestDelHaeds);
            this.panel_editRequest.Controls.Add(this.pb_editRequestCancel);
            this.panel_editRequest.Controls.Add(this.pb_editRequestComfrim);
            this.panel_editRequest.Controls.Add(this.tb_editRequestBody);
            this.panel_editRequest.Controls.Add(this.lb_editHeads);
            this.panel_editRequest.Controls.Add(this.tb_editHeadVaule);
            this.panel_editRequest.Controls.Add(this.tb_editHeadKey);
            this.panel_editRequest.Controls.Add(this.tb_editSartLine);
            this.panel_editRequest.Controls.Add(this.bt_editAddHead);
            this.panel_editRequest.Controls.Add(this.lv_editRequestHeads);
            this.panel_editRequest.Controls.Add(this.cb_editRequestEdition);
            this.panel_editRequest.Controls.Add(this.cb_editRequestMethod);
            this.panel_editRequest.Controls.Add(this.lb_editStartLine);
            this.panel_editRequest.Location = new System.Drawing.Point(3, 342);
            this.panel_editRequest.Name = "panel_editRequest";
            this.panel_editRequest.Size = new System.Drawing.Size(611, 181);
            this.panel_editRequest.TabIndex = 38;
            this.panel_editRequest.Visible = false;
            // 
            // pb_editRequestDelHaeds
            // 
            this.pb_editRequestDelHaeds.BackColor = System.Drawing.Color.Transparent;
            this.pb_editRequestDelHaeds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editRequestDelHaeds.Image = ((System.Drawing.Image)(resources.GetObject("pb_editRequestDelHaeds.Image")));
            this.pb_editRequestDelHaeds.Location = new System.Drawing.Point(583, 30);
            this.pb_editRequestDelHaeds.Name = "pb_editRequestDelHaeds";
            this.pb_editRequestDelHaeds.Size = new System.Drawing.Size(23, 22);
            this.pb_editRequestDelHaeds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editRequestDelHaeds.TabIndex = 38;
            this.pb_editRequestDelHaeds.TabStop = false;
            this.pb_editRequestDelHaeds.Click += new System.EventHandler(this.pb_editRequestDelHaeds_Click);
            this.pb_editRequestDelHaeds.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_editRequestDelHaeds.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_editRequestCancel
            // 
            this.pb_editRequestCancel.BackColor = System.Drawing.Color.Transparent;
            this.pb_editRequestCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editRequestCancel.Image = ((System.Drawing.Image)(resources.GetObject("pb_editRequestCancel.Image")));
            this.pb_editRequestCancel.Location = new System.Drawing.Point(584, 3);
            this.pb_editRequestCancel.Name = "pb_editRequestCancel";
            this.pb_editRequestCancel.Size = new System.Drawing.Size(23, 22);
            this.pb_editRequestCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editRequestCancel.TabIndex = 36;
            this.pb_editRequestCancel.TabStop = false;
            this.pb_editRequestCancel.Click += new System.EventHandler(this.pb_editRequestCancel_Click);
            this.pb_editRequestCancel.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_editRequestCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_editRequestComfrim
            // 
            this.pb_editRequestComfrim.BackColor = System.Drawing.Color.Transparent;
            this.pb_editRequestComfrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editRequestComfrim.Image = ((System.Drawing.Image)(resources.GetObject("pb_editRequestComfrim.Image")));
            this.pb_editRequestComfrim.Location = new System.Drawing.Point(558, 3);
            this.pb_editRequestComfrim.Name = "pb_editRequestComfrim";
            this.pb_editRequestComfrim.Size = new System.Drawing.Size(23, 22);
            this.pb_editRequestComfrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editRequestComfrim.TabIndex = 35;
            this.pb_editRequestComfrim.TabStop = false;
            this.pb_editRequestComfrim.Click += new System.EventHandler(this.pb_editRequestComfrim_Click);
            this.pb_editRequestComfrim.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_editRequestComfrim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // tb_editRequestBody
            // 
            this.tb_editRequestBody.Location = new System.Drawing.Point(5, 56);
            this.tb_editRequestBody.Multiline = true;
            this.tb_editRequestBody.Name = "tb_editRequestBody";
            this.tb_editRequestBody.Size = new System.Drawing.Size(350, 121);
            this.tb_editRequestBody.TabIndex = 23;
            this.tb_editRequestBody.WatermarkText = "Request Body";
            // 
            // lb_editHeads
            // 
            this.lb_editHeads.AutoSize = true;
            this.lb_editHeads.Location = new System.Drawing.Point(3, 37);
            this.lb_editHeads.Name = "lb_editHeads";
            this.lb_editHeads.Size = new System.Drawing.Size(41, 12);
            this.lb_editHeads.TabIndex = 22;
            this.lb_editHeads.Text = "Heads:";
            // 
            // tb_editHeadVaule
            // 
            this.tb_editHeadVaule.Location = new System.Drawing.Point(117, 31);
            this.tb_editHeadVaule.Name = "tb_editHeadVaule";
            this.tb_editHeadVaule.Size = new System.Drawing.Size(174, 21);
            this.tb_editHeadVaule.TabIndex = 21;
            this.tb_editHeadVaule.Text = "Keep-Alive";
            this.tb_editHeadVaule.WatermarkText = "head vaule";
            // 
            // tb_editHeadKey
            // 
            this.tb_editHeadKey.Location = new System.Drawing.Point(44, 31);
            this.tb_editHeadKey.Name = "tb_editHeadKey";
            this.tb_editHeadKey.Size = new System.Drawing.Size(72, 21);
            this.tb_editHeadKey.TabIndex = 20;
            this.tb_editHeadKey.Text = "Connection";
            this.tb_editHeadKey.WatermarkText = "head key";
            // 
            // tb_editSartLine
            // 
            this.tb_editSartLine.Location = new System.Drawing.Point(160, 5);
            this.tb_editSartLine.Name = "tb_editSartLine";
            this.tb_editSartLine.Size = new System.Drawing.Size(305, 21);
            this.tb_editSartLine.TabIndex = 19;
            this.tb_editSartLine.Text = "http://www.baidu.com";
            this.tb_editSartLine.WatermarkText = "http://www.baidu.com";
            // 
            // bt_editAddHead
            // 
            this.bt_editAddHead.Location = new System.Drawing.Point(291, 30);
            this.bt_editAddHead.Name = "bt_editAddHead";
            this.bt_editAddHead.Size = new System.Drawing.Size(64, 23);
            this.bt_editAddHead.TabIndex = 15;
            this.bt_editAddHead.Text = "AddHead>";
            this.bt_editAddHead.UseVisualStyleBackColor = true;
            this.bt_editAddHead.Click += new System.EventHandler(this.bt_editAddHead_Click);
            // 
            // lv_editRequestHeads
            // 
            this.lv_editRequestHeads.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lv_editRequestHeads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_editRequestHeads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_heads});
            this.lv_editRequestHeads.Location = new System.Drawing.Point(361, 29);
            this.lv_editRequestHeads.Name = "lv_editRequestHeads";
            this.lv_editRequestHeads.Size = new System.Drawing.Size(246, 149);
            this.lv_editRequestHeads.TabIndex = 13;
            this.lv_editRequestHeads.UseCompatibleStateImageBehavior = false;
            this.lv_editRequestHeads.View = System.Windows.Forms.View.Details;
            this.lv_editRequestHeads.DoubleClick += new System.EventHandler(this.lv_editRequestHeads_DoubleClick);
            // 
            // columnHeader_heads
            // 
            this.columnHeader_heads.Text = "Heads";
            this.columnHeader_heads.Width = 241;
            // 
            // cb_editRequestEdition
            // 
            this.cb_editRequestEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_editRequestEdition.FormattingEnabled = true;
            this.cb_editRequestEdition.Items.AddRange(new object[] {
            "HTTP/1.1",
            "HTTP/0.9",
            "HTTP/1.0",
            "HTTP/1.2",
            "HTTP/2.0"});
            this.cb_editRequestEdition.Location = new System.Drawing.Point(471, 5);
            this.cb_editRequestEdition.Name = "cb_editRequestEdition";
            this.cb_editRequestEdition.Size = new System.Drawing.Size(78, 20);
            this.cb_editRequestEdition.TabIndex = 12;
            // 
            // cb_editRequestMethod
            // 
            this.cb_editRequestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_editRequestMethod.FormattingEnabled = true;
            this.cb_editRequestMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "HEAD",
            "PUT",
            "DELETE",
            "CONNECT",
            "OPTIONS",
            "TRACE"});
            this.cb_editRequestMethod.Location = new System.Drawing.Point(76, 5);
            this.cb_editRequestMethod.Name = "cb_editRequestMethod";
            this.cb_editRequestMethod.Size = new System.Drawing.Size(78, 20);
            this.cb_editRequestMethod.TabIndex = 10;
            // 
            // lb_editStartLine
            // 
            this.lb_editStartLine.AutoSize = true;
            this.lb_editStartLine.Location = new System.Drawing.Point(3, 9);
            this.lb_editStartLine.Name = "lb_editStartLine";
            this.lb_editStartLine.Size = new System.Drawing.Size(71, 12);
            this.lb_editStartLine.TabIndex = 5;
            this.lb_editStartLine.Text = "Start Line:";
            // 
            // ck_saveResponse
            // 
            this.ck_saveResponse.AutoSize = true;
            this.ck_saveResponse.Location = new System.Drawing.Point(605, 321);
            this.ck_saveResponse.Name = "ck_saveResponse";
            this.ck_saveResponse.Size = new System.Drawing.Size(162, 16);
            this.ck_saveResponse.TabIndex = 39;
            this.ck_saveResponse.Text = "Save Response To Stream";
            this.ck_saveResponse.UseVisualStyleBackColor = true;
            this.ck_saveResponse.CheckedChanged += new System.EventHandler(this.ck_saveResponse_CheckedChanged);
            // 
            // panel_addPipe
            // 
            this.panel_addPipe.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel_addPipe.Controls.Add(this.lb_reConTime);
            this.panel_addPipe.Controls.Add(this.tb_reConTime);
            this.panel_addPipe.Controls.Add(this.lb_responseType);
            this.panel_addPipe.Controls.Add(this.cb_responseType);
            this.panel_addPipe.Controls.Add(this.tb_addTime);
            this.panel_addPipe.Controls.Add(this.bt_addPile);
            this.panel_addPipe.Controls.Add(this.bt_connectAllPile);
            this.panel_addPipe.Controls.Add(this.bt_sendRequest);
            this.panel_addPipe.Controls.Add(this.lb_requestCount);
            this.panel_addPipe.Controls.Add(this.cb_isAsynSend);
            this.panel_addPipe.Controls.Add(this.tb_RequstCount);
            this.panel_addPipe.Location = new System.Drawing.Point(615, 342);
            this.panel_addPipe.Name = "panel_addPipe";
            this.panel_addPipe.Size = new System.Drawing.Size(205, 180);
            this.panel_addPipe.TabIndex = 40;
            // 
            // pb_saveResponseStream
            // 
            this.pb_saveResponseStream.BackColor = System.Drawing.Color.Transparent;
            this.pb_saveResponseStream.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_saveResponseStream.Image = ((System.Drawing.Image)(resources.GetObject("pb_saveResponseStream.Image")));
            this.pb_saveResponseStream.Location = new System.Drawing.Point(792, 318);
            this.pb_saveResponseStream.Name = "pb_saveResponseStream";
            this.pb_saveResponseStream.Size = new System.Drawing.Size(23, 22);
            this.pb_saveResponseStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_saveResponseStream.TabIndex = 39;
            this.pb_saveResponseStream.TabStop = false;
            this.pb_saveResponseStream.Visible = false;
            this.pb_saveResponseStream.Click += new System.EventHandler(this.pb_saveResponseStream_Click);
            // 
            // lb_getResponseState
            // 
            this.lb_getResponseState.AutoSize = true;
            this.lb_getResponseState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_getResponseState.ForeColor = System.Drawing.Color.LimeGreen;
            this.lb_getResponseState.Location = new System.Drawing.Point(766, 321);
            this.lb_getResponseState.Name = "lb_getResponseState";
            this.lb_getResponseState.Size = new System.Drawing.Size(24, 16);
            this.lb_getResponseState.TabIndex = 41;
            this.lb_getResponseState.Text = "●";
            this.lb_getResponseState.Visible = false;
            // 
            // PipeHttpRuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 527);
            this.Controls.Add(this.lb_getResponseState);
            this.Controls.Add(this.rtb_dataRecieve);
            this.Controls.Add(this.pb_saveResponseStream);
            this.Controls.Add(this.panel_addPipe);
            this.Controls.Add(this.ck_saveResponse);
            this.Controls.Add(this.panel_editRequest);
            this.Controls.Add(this.pb_editRawRequest);
            this.Controls.Add(this.tb_rawRequest);
            this.Controls.Add(this.lv_pipeList);
            this.Controls.Add(this.lb_pipeHost);
            this.Controls.Add(this.tb_pilePort);
            this.Controls.Add(this.tb_pileHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(978, 566);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(978, 566);
            this.Name = "PipeHttpRuner";
            this.Text = "PipeHttp";
            this.Load += new System.EventHandler(this.PipeHttpRuner_Load);
            this.contextMenuStrip_forPipeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRawRequest)).EndInit();
            this.panel_editRequest.ResumeLayout(false);
            this.panel_editRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestDelHaeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editRequestComfrim)).EndInit();
            this.panel_addPipe.ResumeLayout(false);
            this.panel_addPipe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_saveResponseStream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCommonControl.DataRecordBox rtb_dataRecieve;
        private MyCommonControl.Control.TextBoxWithWatermak tb_pileHost;
        private MyCommonControl.Control.TextBoxWithWatermak tb_pilePort;
        private System.Windows.Forms.Label lb_pipeHost;
        private System.Windows.Forms.ListView lv_pipeList;
        private System.Windows.Forms.ColumnHeader columnHeader_id;
        private System.Windows.Forms.ColumnHeader columnHeader_reConectCount;
        private MyCommonControl.Control.TextBoxWithWatermak tb_reConTime;
        private System.Windows.Forms.Label lb_reConTime;
        private System.Windows.Forms.Label lb_responseType;
        private System.Windows.Forms.ComboBox cb_responseType;
        private MyCommonControl.Control.TextBoxWithWatermak tb_addTime;
        private System.Windows.Forms.Button bt_addPile;
        private System.Windows.Forms.Button bt_sendRequest;
        private System.Windows.Forms.CheckBox cb_isAsynSend;
        private MyCommonControl.Control.TextBoxWithWatermak tb_RequstCount;
        private System.Windows.Forms.Label lb_requestCount;
        private System.Windows.Forms.Button bt_connectAllPile;
        private System.Windows.Forms.TextBox tb_rawRequest;
        private System.Windows.Forms.PictureBox pb_editRawRequest;
        private System.Windows.Forms.Panel panel_editRequest;
        private System.Windows.Forms.PictureBox pb_editRequestDelHaeds;
        private System.Windows.Forms.PictureBox pb_editRequestCancel;
        private System.Windows.Forms.PictureBox pb_editRequestComfrim;
        private MyCommonControl.Control.TextBoxWithWatermak tb_editRequestBody;
        private System.Windows.Forms.Label lb_editHeads;
        private MyCommonControl.Control.TextBoxWithWatermak tb_editHeadVaule;
        private MyCommonControl.Control.TextBoxWithWatermak tb_editHeadKey;
        private MyCommonControl.Control.TextBoxWithWatermak tb_editSartLine;
        private System.Windows.Forms.Button bt_editAddHead;
        private System.Windows.Forms.ListView lv_editRequestHeads;
        private System.Windows.Forms.ColumnHeader columnHeader_heads;
        private System.Windows.Forms.ComboBox cb_editRequestEdition;
        private System.Windows.Forms.ComboBox cb_editRequestMethod;
        private System.Windows.Forms.Label lb_editStartLine;
        private System.Windows.Forms.CheckBox ck_saveResponse;
        private System.Windows.Forms.Panel panel_addPipe;
        private System.Windows.Forms.PictureBox pb_saveResponseStream;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_forPipeList;
        private System.Windows.Forms.ToolStripMenuItem removeThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectAllToolStripMenuItem;
        private System.Windows.Forms.Label lb_getResponseState;
    }
}

