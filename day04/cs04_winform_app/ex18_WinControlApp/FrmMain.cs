namespace ex18_WinControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // ��� Ʈ���� ������
        public FrmMain()
        {
            InitializeComponent(); // �����̳ʿ��� ������ ȭ�� ���� �ʱ�ȭ

            lsv.Columns.Add("�̸�");
            lsv.Columns.Add("����");
        }

        // ����ü, ����, ���Ÿ����� �����ϴ� �޼���
        void ChangeFont()
        {
            if (CboFont.SelectedIndex == 0) // �ƹ��͵� ���� �ȵ�
                return;

            FontStyle style = FontStyle.Regular; // �Ϲ� ����(���)�� �ʱ�ȭ
            if (ChkBold.Checked) style |= FontStyle.Bold;

            if (ChkItalic.Checked) style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFont.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            lsv.Items.Clear();
            foreach (TreeNode node in trv.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            lsv.Items.Add(new ListViewItem(new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }));
            foreach (TreeNode subnode in node.Nodes)
            {
                TreeToList(subnode);
            }
        }

        private void CboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }
        private void FrmMain_Load_1(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // ���� OS���� ��ġ�� ��Ʈ�� ������
            foreach (var font in Fonts)
            {
                CboFont.Items.Add(font.Name);
            }
        }

        // trackbar scroll event handeller
        private void trB1_Scroll(object sender, EventArgs e)
        {
            prgDummy.Value = trB1.Value; // Ʈ���� �����͸� �ű�� ���α׷����� ���� ���̺���
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "���â";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Yellow;
            FrmModal.ShowDialog(); // ���â ����

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "���â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            FrmModaless.Show();
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSampleText.Text, "�޽��� �ڽ�", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("���ƿ�?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("�� ���ƿ�~");

            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("�ʹ� �Ⱦ��");
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("���� �����ϰڽ��ϱ�?", "���Ῡ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnaddroot_Click(object sender, EventArgs e)
        {
            trv.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddchild_Click(object sender, EventArgs e)
        {
            if (trv.SelectedNode == null) // �θ��带 �������� ������
            {
                MessageBox.Show("������ ��尡 ����", "���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            trv.SelectedNode.Nodes.Add(rand.Next().ToString());
            trv.SelectedNode.Expand();
            TreeToList(); // �����並 �ٽ� �׸�
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "�̹��� ����";
            DlgOpenImage.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            var res = DlgOpenImage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNomal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }

        private void PicNomal_Click(object sender, EventArgs e)
        {
            if(PicNomal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNomal.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            { PicNomal.SizeMode = PictureBoxSizeMode.Normal; }
        }
    }

}
