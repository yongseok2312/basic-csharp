using System.ComponentModel;
using System.Threading; // ������ Ŭ���� �����

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

            GrbEditor.Text = "�ؽ�Ʈ ������";

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
            FrmModal.StartPosition = FormStartPosition.CenterParent;
            FrmModal.ShowDialog(); // ���â ����

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "���â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            FrmModaless.StartPosition = FormStartPosition.Manual;
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2, this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(this);
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
            if (PicNomal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNomal.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            { PicNomal.SizeMode = PictureBoxSizeMode.Normal; }
        }

        // �ؽ�Ʈ ���� �ε� �̺�Ʈ �ڵ鷯
        private void btnfileload_Click(object sender, EventArgs e)
        {
            // OpenFileDialog ��Ʈ���� �����ο��� �������� �ʰ� �����ϴ� ���
            OpenFileDialog diaog = new OpenFileDialog();
            diaog.Multiselect = false;  // ������ ���� ���ñ���
            diaog.Filter = "Text Files(*.txt;*.cs;*.py)|*.txt;*.cs;*.py";
            if (diaog.ShowDialog() == DialogResult.OK)
            {
                // utf-8�� ����, EUC-KR(window 949), UTF-8 Bom�� �ѱ� ������ ����
                RtxEditor.LoadFile(diaog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        // �ؽ�Ʈ ���� ���� �̺�Ʈ �ڵ鷯
        private void btnfilesave_Click(object sender, EventArgs e)
        {
            SaveFileDialog diaog = new SaveFileDialog();
            diaog.Filter = "RichText Files(*.rtf)|*.rtf";
            if (diaog.ShowDialog(this) == DialogResult.OK)
            {
                RtxEditor.SaveFile(diaog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }

        private void nothread_Click(object sender, EventArgs e)
        {
            // ���α׷����� ����
            var maxValue = 100;
            var currValue = 0;
            prgpr.Minimum = 0;
            prgpr.Maximum = maxValue;
            prgpr.Value = 0; // 0���� �ʱ�ȭ

            thread.Enabled = false;
            nothread.Enabled = false;
            stop.Enabled = true;

            for (var i = 0; i <= maxValue; i++)
            {
                currValue = i;
                prgpr.Value = currValue;
                textBox1.AppendText($"�������� : {currValue}\r\n");
                Thread.Sleep(500);

            }
            thread.Enabled = nothread.Enabled = true;
            stop.Enabled = false;
        }

        private void thread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            prgpr.Minimum = 0;
            prgpr.Maximum = maxValue;
            prgpr.Value = 0;

            thread.Enabled = false;
            nothread.Enabled = false;
            stop.Enabled = true;

            bgwprogress.WorkerReportsProgress = true;   // ������� ����Ʈ Ȱ��ȭ
            bgwprogress.WorkerSupportsCancellation = true;  // ��׶��� ��Ŀ ���
            bgwprogress.RunWorkerAsync(null);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            bgwprogress.CancelAsync(); // �񵿱�� ��� ����!
        }

        #region '��׶��� ��Ŀ'
        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var maxValue = 100;
            double currValue = 0; // �Ǽ������� ����
            for (var i = 0;i <= maxValue;i++)
            {
                if (worker.CancellationPending) // �߰��� ����Ұ��� ����� ��
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currValue = i;
                    Thread.Sleep(500);

                    // �Ʒ��� �����ϸ�, BgwProgress_ProgressChanged �̺�Ʈ�ڵ鷯��
                    // ProgressChangedEventArgs���� ProgressPercentage �Ӽ��� ���� ��
                    worker.ReportProgress((int)((currValue / maxValue) * 100));
                }
            }
        }
        // ���� ����
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e);
            e.Result = null;
        }

        // ������� �ٲ�� �� ǥ��
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            prgpr.Value = e.ProgressPercentage;
            textBox1.AppendText($"����� : {prgpr.Value}%\r\n");
        }

        // ������ �Ϸ�Ǹ� �� ���� ó��
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                textBox1.AppendText("�۾��� ��ҵǾ����ϴ�.\r\n");
            }
            else
            {
                textBox1.AppendText("�۾��� �Ϸ�Ǿ����ϴ�.\r\n");
            }

            nothread.Enabled = thread.Enabled = true;
            stop.Enabled = false;
        }
        #endregion
    }

}
