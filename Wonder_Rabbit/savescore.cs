using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wonder_Rabbit
{
    public partial class savescore : Form
    {
        public int score;   //점수를 저장하는 변수 --> 메인폼에서 게임이 끝나면 클래스 인스턴스에 점수 넣어줌
        private StreamReader read;      //
        private StreamWriter write;     //
        private FileStream f;           //파일에 스트림을 하기 위한 변수들
        private List<string> readString = new List<string>();   //파일에서 불러온 문자열을 저장할 List
        private Rank data = new Rank();     //데이터셋 생성
        public Boolean Highscore_Btn = false;   //이 폼이 버튼을 통해 열렸는지, 게임이 끝나서 점수를 저장하기 위해 열렸는지 검사

        public savescore()
        {
            InitializeComponent();
        }

        private void savescore_Load(object sender, EventArgs e) //폼 로드시
        {
            if (Highscore_Btn)
                nameTextBox.Enabled = false;        //버튼을 통해 접근했다면 점수를 등록해서는 안됨 --> 이름 입력 텍스트박스 비활성화

            int index = 0;
            try
            {
                string str = "";
                f = new FileStream(Application.StartupPath + @"\Rank.txt", FileMode.Open);//파일을 열고
                read = new StreamReader(f);
                write = new StreamWriter(f);    //스트림 초기화

                while(str != null)
                {
                    str = read.ReadLine();  //파일을 한 줄 읽어서
                    if (str == null)
                        break;
                    readString.Add(str);    //문자열을 List에 추가
                    index++;
                }

                index = 0;

                if (readString == null)     //파일에 아무것도 없다면 밑의 행동을 할 필요가 없음 --> return
                    return;

                foreach(string s in readString)
                {
                    string[] split;
                    split = s.Split('|');       //split 메소드를 통해서 string 배열에 이름과 점수 나눠서 저장
                    data.Tables["Rank"].Rows.Add(new object[] { split[0], Convert.ToInt32(split[1]) } );    //나눈 문자열을 데이터테이블에 추가
                }

                DataTable values = data.Tables["Rank"];

                IEnumerable<DataRow> query =    //데이터셋에 추가된 테이터들을 query와 orderby절을 통해 높은점수부터 query에 저장
                    from score in values.AsEnumerable()
                    orderby Convert.ToInt32(score["Score"]) descending
                    select score;

                int i = 0;

                foreach(DataRow dr in query)    //query에 있는 tuple들을 위에서부터 5개만 출력
                {
                    i++;
                    this.rankTextBox.AppendText(i + ". Name : " + dr["Name"].ToString() + "     Score : " + dr["Score"] + "\n");
                    if (i == 5)
                        break;
                }

                if(!Highscore_Btn)
                    MessageBox.Show("내 점수 : " + score); //게임이 끝나서 이 폼이 나온 경우에는 자신의 점수를 보여준다.
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)  //완료버튼 클릭시
        {
            try
            {
                if(!Highscore_Btn)  //버튼을 눌러서 접근한 경우에는 파일에 무언가를 쓰면 안됨
                {
                    write.WriteLine(nameTextBox.Text + "|" + score);    //이름|점수 식으로 파일에 쓰고
                    write.Flush();                                      //보낸다
                }
                this.Close();       //창을 닫는다.
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void savescore_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                read.Close();
                write.Close();
                f.Dispose();
                f.Close();  //리소스 해제
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)  //랭킹 초기화
        {
            try
            {
                f.Close();  //파일을 닫고
            }
            catch { }
            f = new FileStream(Application.StartupPath + @"\Rank.txt", FileMode.Create);
            read = new StreamReader(f);
            write = new StreamWriter(f);    //파일을 다시 Create모드로 열어 파일을 초기화하고
            rankTextBox.Text = "";          //랭킹을 표시하는 TextBox를 비운다.
        }
    }
}
