namespace OtoGalari_otomasyonu
{
    partial class Form_Hesap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Hesap));
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnBilgiGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.pnlIslemler = new DevExpress.XtraEditors.SidePanel();
            this.pnlIlanlariGoster = new DevExpress.XtraEditors.SidePanel();
            this.pnlIlanlar = new DevExpress.XtraEditors.SidePanel();
            this.pnlBaslik = new DevExpress.XtraEditors.SidePanel();
            this.lblIlanlarim = new DevExpress.XtraEditors.LabelControl();
            this.pnlGuncelle_Sil = new DevExpress.XtraEditors.SidePanel();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnSifreGoster = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeniSifreGoster = new DevExpress.XtraEditors.SimpleButton();
            this.checkbtnSifreGuncelle = new DevExpress.XtraEditors.CheckButton();
            this.lblYeniSifreT = new System.Windows.Forms.Label();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.lblYeniSifre = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblTelefonNo = new System.Windows.Forms.Label();
            this.lblEposta = new System.Windows.Forms.Label();
            this.lblSoyisim = new System.Windows.Forms.Label();
            this.lblIsim = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifreT = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtTelefonNo = new DevExpress.XtraEditors.TextEdit();
            this.txtEposta = new DevExpress.XtraEditors.TextEdit();
            this.txtSoyisim = new DevExpress.XtraEditors.TextEdit();
            this.txtIsim = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.btnIlanGoster = new DevExpress.XtraEditors.SimpleButton();
            this.btnHesapSil = new DevExpress.XtraEditors.SimpleButton();
            this.pnlIslemler.SuspendLayout();
            this.pnlIlanlariGoster.SuspendLayout();
            this.pnlBaslik.SuspendLayout();
            this.pnlGuncelle_Sil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEposta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.AllowFocus = false;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 50);
            this.btnBack.TabIndex = 0;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBilgiGuncelle
            // 
            this.btnBilgiGuncelle.AllowFocus = false;
            this.btnBilgiGuncelle.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnBilgiGuncelle.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBilgiGuncelle.Appearance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilgiGuncelle.Appearance.Options.UseBackColor = true;
            this.btnBilgiGuncelle.Appearance.Options.UseFont = true;
            this.btnBilgiGuncelle.Location = new System.Drawing.Point(98, 12);
            this.btnBilgiGuncelle.Name = "btnBilgiGuncelle";
            this.btnBilgiGuncelle.Size = new System.Drawing.Size(202, 50);
            this.btnBilgiGuncelle.TabIndex = 0;
            this.btnBilgiGuncelle.Text = "Bilgilerimi Güncelle";
            this.btnBilgiGuncelle.Click += new System.EventHandler(this.btnBilgiGuncelle_Click);
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.AutoScroll = true;
            this.pnlIslemler.Controls.Add(this.pnlIlanlariGoster);
            this.pnlIslemler.Controls.Add(this.pnlGuncelle_Sil);
            this.pnlIslemler.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlIslemler.Location = new System.Drawing.Point(10, 70);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Size = new System.Drawing.Size(730, 570);
            this.pnlIslemler.TabIndex = 2;
            // 
            // pnlIlanlariGoster
            // 
            this.pnlIlanlariGoster.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlIlanlariGoster.Appearance.Options.UseBackColor = true;
            this.pnlIlanlariGoster.AutoScroll = true;
            this.pnlIlanlariGoster.Controls.Add(this.pnlIlanlar);
            this.pnlIlanlariGoster.Controls.Add(this.pnlBaslik);
            this.pnlIlanlariGoster.Location = new System.Drawing.Point(10, 10);
            this.pnlIlanlariGoster.Name = "pnlIlanlariGoster";
            this.pnlIlanlariGoster.Size = new System.Drawing.Size(710, 550);
            this.pnlIlanlariGoster.TabIndex = 4;
            this.pnlIlanlariGoster.Visible = false;
            // 
            // pnlIlanlar
            // 
            this.pnlIlanlar.AutoScroll = true;
            this.pnlIlanlar.Location = new System.Drawing.Point(0, 62);
            this.pnlIlanlar.Name = "pnlIlanlar";
            this.pnlIlanlar.Size = new System.Drawing.Size(710, 488);
            this.pnlIlanlar.TabIndex = 2;
            this.pnlIlanlar.Text = "sidePanel1";
            // 
            // pnlBaslik
            // 
            this.pnlBaslik.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlBaslik.Appearance.Options.UseBackColor = true;
            this.pnlBaslik.Controls.Add(this.lblIlanlarim);
            this.pnlBaslik.Location = new System.Drawing.Point(0, 0);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(710, 56);
            this.pnlBaslik.TabIndex = 1;
            this.pnlBaslik.Text = "sidePanel1";
            // 
            // lblIlanlarim
            // 
            this.lblIlanlarim.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.lblIlanlarim.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIlanlarim.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblIlanlarim.Appearance.Options.UseBackColor = true;
            this.lblIlanlarim.Appearance.Options.UseFont = true;
            this.lblIlanlarim.Appearance.Options.UseForeColor = true;
            this.lblIlanlarim.Location = new System.Drawing.Point(276, 10);
            this.lblIlanlarim.Name = "lblIlanlarim";
            this.lblIlanlarim.Size = new System.Drawing.Size(158, 36);
            this.lblIlanlarim.TabIndex = 0;
            this.lblIlanlarim.Text = "İLANLARIM";
            // 
            // pnlGuncelle_Sil
            // 
            this.pnlGuncelle_Sil.Controls.Add(this.btnSil);
            this.pnlGuncelle_Sil.Controls.Add(this.btnSifreGoster);
            this.pnlGuncelle_Sil.Controls.Add(this.btnYeniSifreGoster);
            this.pnlGuncelle_Sil.Controls.Add(this.checkbtnSifreGuncelle);
            this.pnlGuncelle_Sil.Controls.Add(this.lblYeniSifreT);
            this.pnlGuncelle_Sil.Controls.Add(this.btnGuncelle);
            this.pnlGuncelle_Sil.Controls.Add(this.lblYeniSifre);
            this.pnlGuncelle_Sil.Controls.Add(this.lblSifre);
            this.pnlGuncelle_Sil.Controls.Add(this.lblTelefonNo);
            this.pnlGuncelle_Sil.Controls.Add(this.lblEposta);
            this.pnlGuncelle_Sil.Controls.Add(this.lblSoyisim);
            this.pnlGuncelle_Sil.Controls.Add(this.lblIsim);
            this.pnlGuncelle_Sil.Controls.Add(this.lblKullaniciAdi);
            this.pnlGuncelle_Sil.Controls.Add(this.txtSifre);
            this.pnlGuncelle_Sil.Controls.Add(this.txtYeniSifreT);
            this.pnlGuncelle_Sil.Controls.Add(this.txtYeniSifre);
            this.pnlGuncelle_Sil.Controls.Add(this.txtTelefonNo);
            this.pnlGuncelle_Sil.Controls.Add(this.txtEposta);
            this.pnlGuncelle_Sil.Controls.Add(this.txtSoyisim);
            this.pnlGuncelle_Sil.Controls.Add(this.txtIsim);
            this.pnlGuncelle_Sil.Controls.Add(this.txtKullaniciAdi);
            this.pnlGuncelle_Sil.Location = new System.Drawing.Point(170, 39);
            this.pnlGuncelle_Sil.Name = "pnlGuncelle_Sil";
            this.pnlGuncelle_Sil.Size = new System.Drawing.Size(410, 470);
            this.pnlGuncelle_Sil.TabIndex = 3;
            this.pnlGuncelle_Sil.Visible = false;
            // 
            // btnSil
            // 
            this.btnSil.AllowFocus = false;
            this.btnSil.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Location = new System.Drawing.Point(161, 404);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(200, 40);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Hesabımı Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnSifreGoster
            // 
            this.btnSifreGoster.AllowFocus = false;
            this.btnSifreGoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSifreGoster.BackgroundImage")));
            this.btnSifreGoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSifreGoster.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnSifreGoster.Location = new System.Drawing.Point(369, 353);
            this.btnSifreGoster.Name = "btnSifreGoster";
            this.btnSifreGoster.Size = new System.Drawing.Size(32, 32);
            this.btnSifreGoster.TabIndex = 4;
            this.btnSifreGoster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseDown);
            this.btnSifreGoster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSifreGoster_MouseUp);
            // 
            // btnYeniSifreGoster
            // 
            this.btnYeniSifreGoster.AllowFocus = false;
            this.btnYeniSifreGoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYeniSifreGoster.BackgroundImage")));
            this.btnYeniSifreGoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYeniSifreGoster.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnYeniSifreGoster.Location = new System.Drawing.Point(369, 257);
            this.btnYeniSifreGoster.Name = "btnYeniSifreGoster";
            this.btnYeniSifreGoster.Size = new System.Drawing.Size(32, 32);
            this.btnYeniSifreGoster.TabIndex = 4;
            this.btnYeniSifreGoster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYeniSifreGoster_MouseDown);
            this.btnYeniSifreGoster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYeniSifreGoster_MouseUp);
            // 
            // checkbtnSifreGuncelle
            // 
            this.checkbtnSifreGuncelle.AllowFocus = false;
            this.checkbtnSifreGuncelle.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkbtnSifreGuncelle.Appearance.Options.UseFont = true;
            this.checkbtnSifreGuncelle.Location = new System.Drawing.Point(161, 220);
            this.checkbtnSifreGuncelle.Name = "checkbtnSifreGuncelle";
            this.checkbtnSifreGuncelle.Size = new System.Drawing.Size(200, 32);
            this.checkbtnSifreGuncelle.TabIndex = 5;
            this.checkbtnSifreGuncelle.Text = "Şifre Güncelle";
            this.checkbtnSifreGuncelle.CheckedChanged += new System.EventHandler(this.checkbtnSifreGuncelle_CheckedChanged);
            // 
            // lblYeniSifreT
            // 
            this.lblYeniSifreT.AutoSize = true;
            this.lblYeniSifreT.Location = new System.Drawing.Point(3, 296);
            this.lblYeniSifreT.Name = "lblYeniSifreT";
            this.lblYeniSifreT.Size = new System.Drawing.Size(141, 28);
            this.lblYeniSifreT.TabIndex = 1;
            this.lblYeniSifreT.Text = "Yeni Şifre (T) :";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.AllowFocus = false;
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.Location = new System.Drawing.Point(161, 404);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(200, 40);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // lblYeniSifre
            // 
            this.lblYeniSifre.AutoSize = true;
            this.lblYeniSifre.Location = new System.Drawing.Point(28, 258);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new System.Drawing.Size(116, 28);
            this.lblYeniSifre.TabIndex = 1;
            this.lblYeniSifre.Text = "Yeni Şifre : ";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(78, 351);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(66, 28);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre :";
            // 
            // lblTelefonNo
            // 
            this.lblTelefonNo.AutoSize = true;
            this.lblTelefonNo.Location = new System.Drawing.Point(21, 169);
            this.lblTelefonNo.Name = "lblTelefonNo";
            this.lblTelefonNo.Size = new System.Drawing.Size(123, 28);
            this.lblTelefonNo.TabIndex = 1;
            this.lblTelefonNo.Text = "Telefon No :";
            // 
            // lblEposta
            // 
            this.lblEposta.AutoSize = true;
            this.lblEposta.Location = new System.Drawing.Point(52, 131);
            this.lblEposta.Name = "lblEposta";
            this.lblEposta.Size = new System.Drawing.Size(92, 28);
            this.lblEposta.TabIndex = 1;
            this.lblEposta.Text = "e-posta :";
            // 
            // lblSoyisim
            // 
            this.lblSoyisim.AutoSize = true;
            this.lblSoyisim.Location = new System.Drawing.Point(51, 93);
            this.lblSoyisim.Name = "lblSoyisim";
            this.lblSoyisim.Size = new System.Drawing.Size(93, 28);
            this.lblSoyisim.TabIndex = 1;
            this.lblSoyisim.Text = "Soyisim :";
            // 
            // lblIsim
            // 
            this.lblIsim.AutoSize = true;
            this.lblIsim.Location = new System.Drawing.Point(83, 55);
            this.lblIsim.Name = "lblIsim";
            this.lblIsim.Size = new System.Drawing.Size(61, 28);
            this.lblIsim.TabIndex = 1;
            this.lblIsim.Text = "İsim :";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(7, 17);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(137, 28);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı :";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(161, 351);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.AllowFocused = false;
            this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSifre.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSifre.Properties.MaxLength = 15;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(200, 32);
            this.txtSifre.TabIndex = 8;
            // 
            // txtYeniSifreT
            // 
            this.txtYeniSifreT.Enabled = false;
            this.txtYeniSifreT.Location = new System.Drawing.Point(161, 296);
            this.txtYeniSifreT.Name = "txtYeniSifreT";
            this.txtYeniSifreT.Properties.AllowFocused = false;
            this.txtYeniSifreT.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifreT.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifreT.Properties.Appearance.Options.UseTextOptions = true;
            this.txtYeniSifreT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtYeniSifreT.Properties.MaxLength = 15;
            this.txtYeniSifreT.Properties.PasswordChar = '●';
            this.txtYeniSifreT.Size = new System.Drawing.Size(200, 32);
            this.txtYeniSifreT.TabIndex = 7;
            this.txtYeniSifreT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYeniSifreT_KeyPress);
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Enabled = false;
            this.txtYeniSifre.Location = new System.Drawing.Point(161, 258);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.AllowFocused = false;
            this.txtYeniSifre.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniSifre.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifre.Properties.Appearance.Options.UseTextOptions = true;
            this.txtYeniSifre.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtYeniSifre.Properties.MaxLength = 15;
            this.txtYeniSifre.Properties.PasswordChar = '●';
            this.txtYeniSifre.Size = new System.Drawing.Size(200, 32);
            this.txtYeniSifre.TabIndex = 6;
            this.txtYeniSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYeniSifre_KeyPress);
            // 
            // txtTelefonNo
            // 
            this.txtTelefonNo.Location = new System.Drawing.Point(161, 169);
            this.txtTelefonNo.Name = "txtTelefonNo";
            this.txtTelefonNo.Properties.AllowFocused = false;
            this.txtTelefonNo.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTelefonNo.Properties.Appearance.Options.UseFont = true;
            this.txtTelefonNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTelefonNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTelefonNo.Properties.MaxLength = 11;
            this.txtTelefonNo.Size = new System.Drawing.Size(200, 32);
            this.txtTelefonNo.TabIndex = 4;
            this.txtTelefonNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonNo_KeyPress);
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(161, 131);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Properties.AllowFocused = false;
            this.txtEposta.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.Properties.Appearance.Options.UseFont = true;
            this.txtEposta.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEposta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtEposta.Properties.MaxLength = 25;
            this.txtEposta.Size = new System.Drawing.Size(200, 32);
            this.txtEposta.TabIndex = 3;
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(161, 93);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Properties.AllowFocused = false;
            this.txtSoyisim.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyisim.Properties.Appearance.Options.UseFont = true;
            this.txtSoyisim.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSoyisim.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSoyisim.Properties.MaxLength = 15;
            this.txtSoyisim.Size = new System.Drawing.Size(200, 32);
            this.txtSoyisim.TabIndex = 2;
            this.txtSoyisim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoyisim_KeyPress);
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(161, 55);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Properties.AllowFocused = false;
            this.txtIsim.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIsim.Properties.Appearance.Options.UseFont = true;
            this.txtIsim.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIsim.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIsim.Properties.MaxLength = 15;
            this.txtIsim.Size = new System.Drawing.Size(200, 32);
            this.txtIsim.TabIndex = 1;
            this.txtIsim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIsim_KeyPress);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Enabled = false;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(161, 17);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.AllowFocused = false;
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKullaniciAdi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 32);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // btnIlanGoster
            // 
            this.btnIlanGoster.AllowFocus = false;
            this.btnIlanGoster.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnIlanGoster.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIlanGoster.Appearance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIlanGoster.Appearance.Options.UseBackColor = true;
            this.btnIlanGoster.Appearance.Options.UseFont = true;
            this.btnIlanGoster.Location = new System.Drawing.Point(320, 12);
            this.btnIlanGoster.Name = "btnIlanGoster";
            this.btnIlanGoster.Size = new System.Drawing.Size(200, 50);
            this.btnIlanGoster.TabIndex = 1;
            this.btnIlanGoster.Text = "İlanlarımı Göster";
            this.btnIlanGoster.Click += new System.EventHandler(this.btnIlanGoster_Click);
            // 
            // btnHesapSil
            // 
            this.btnHesapSil.AllowFocus = false;
            this.btnHesapSil.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnHesapSil.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnHesapSil.Appearance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHesapSil.Appearance.Options.UseBackColor = true;
            this.btnHesapSil.Appearance.Options.UseFont = true;
            this.btnHesapSil.Location = new System.Drawing.Point(540, 12);
            this.btnHesapSil.Name = "btnHesapSil";
            this.btnHesapSil.Size = new System.Drawing.Size(200, 50);
            this.btnHesapSil.TabIndex = 2;
            this.btnHesapSil.Text = "Hesabımı Sil";
            this.btnHesapSil.Click += new System.EventHandler(this.btnHesapSil_Click);
            // 
            // Form_Hesap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(752, 653);
            this.Controls.Add(this.pnlIslemler);
            this.Controls.Add(this.btnHesapSil);
            this.Controls.Add(this.btnIlanGoster);
            this.Controls.Add(this.btnBilgiGuncelle);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Hesap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Hesap";
            this.Load += new System.EventHandler(this.Form_Hesap_Load);
            this.pnlIslemler.ResumeLayout(false);
            this.pnlIlanlariGoster.ResumeLayout(false);
            this.pnlBaslik.ResumeLayout(false);
            this.pnlBaslik.PerformLayout();
            this.pnlGuncelle_Sil.ResumeLayout(false);
            this.pnlGuncelle_Sil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEposta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnBilgiGuncelle;
        private DevExpress.XtraEditors.SidePanel pnlIslemler;
        private DevExpress.XtraEditors.SimpleButton btnIlanGoster;
        private DevExpress.XtraEditors.SimpleButton btnHesapSil;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private System.Windows.Forms.Label lblTelefonNo;
        private System.Windows.Forms.Label lblEposta;
        private System.Windows.Forms.Label lblSoyisim;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifreT;
        private DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private DevExpress.XtraEditors.TextEdit txtTelefonNo;
        private DevExpress.XtraEditors.TextEdit txtEposta;
        private DevExpress.XtraEditors.TextEdit txtSoyisim;
        private DevExpress.XtraEditors.TextEdit txtIsim;
        private System.Windows.Forms.Label lblSifre;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private System.Windows.Forms.Label lblYeniSifreT;
        private System.Windows.Forms.Label lblYeniSifre;
        private DevExpress.XtraEditors.SidePanel pnlGuncelle_Sil;
        private DevExpress.XtraEditors.CheckButton checkbtnSifreGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnYeniSifreGoster;
        private DevExpress.XtraEditors.SimpleButton btnSifreGoster;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SidePanel pnlIlanlariGoster;
        private DevExpress.XtraEditors.LabelControl lblIlanlarim;
        private DevExpress.XtraEditors.SidePanel pnlIlanlar;
        private DevExpress.XtraEditors.SidePanel pnlBaslik;
    }
}