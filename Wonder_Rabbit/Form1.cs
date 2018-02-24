using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FMOD;//BGM

namespace Wonder_Rabbit
{
    public partial class mainForm : Form
    {
        private const int MAX_OBJ_NUMBER = 30;  // 화면에 생성될 폭탄과 과일의 최대 갯수
        private int dropItems_Size = 25;        // 폭탄과 과일의 크기
        private int speed = 10;                 // 토끼의 속도
        private int Maxp = 15;                  // 폭탄과 과일을 발생시키는 확률
        private int cloudSpeed = 5;             // 구름의 속도

        private bool key_Left = false;          // 왼쪽키가 눌렸는지 확인하는 플래그
        private bool key_Right = false;         // 오른쪽키가 눌렸는지 확인하는 플래그
        private bool gaming = false;            // 현재 게임 중인지 확인하는 부울형 변수
        private bool madRabbit = false;         // 화난 토끼 기능을 켜고 끄는 플래그
        private bool cloudDirection = true;     // 구름은 항상 이동하고 있는데, 
                                                // 이동하는 구름의 방향을 true, false로 결정한다


        private Thread eat_Thread;              // 토끼가 과일이나 폭탄을 먹었거나,
                                                // 폭탄이나 과일이 땅에 떨어졌을 때 처리하는 쓰레드

        private Thread drop_Thread;             // 화면에 표시된 과일이나 폭탄을 떨어뜨리는 쓰레드

        private BGMPlayer player;               // BGM 재생을 위한 클래스(FMOD) 

        private Pic[] Bombs;                    // 폭탄이나 과일의 picturebox를 저장할 배열

        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game_over_Label.BackColor = Color.Transparent;
            game_over_Label.Parent = Dfield;
            game_over_Label.Visible = false;            // 게임오버시 표시해줄 라벨 설정

            rabbit_Pic.Location = new Point(0, 350);    // 토끼 초기 위치 이동

            stateBox.BackColor = Color.Transparent;
            stateBox.Parent = leftDock;                 // stabeBox의 배경 투명하게 지정

            rabbit_Pic.BackColor = Color.Transparent;
            rabbit_Pic.Parent = Dfield;                 // 토끼의 배경 투명하게 지정

            cloud_Pic.BackColor = Color.Transparent;
            cloud_Pic.Parent = Dfield;                  // 구름의 배경 투명하게 지정

            this.KeyPreview = true;                     // 키이벤트를 받아오기 위해 true
        }

        private int GetNotNULL(Pic[] arr) //배열 중 몇개가 할당되었는지 확인
        {
            int x = 0;          // private Pic[] Bombs 배열의 빈 인덱스 찾기
            foreach (Pic a in arr)
            {
                if (a != null)
                {
                    x++;
                }
            }
            return x;
        }

        private int GetIndex(Pic[] arr)  //어떤 인덱스를 쓸지 정하는 메소드
        {
            if (GetNotNULL(arr) < arr.Length)   //할당된 수를 검사하고
            {
                for (int i = 0; i < MAX_OBJ_NUMBER; i++)
                    if (arr[i] == null)         //null인 index를 return
                        return i;
            }
            arr[0] = null;                      //만약 null인 index가 없으면
            return 0;                           //인덱스 0을 null로 만든 후 return
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)    //KeyEvent 처리함수
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad4:              // Numpad4 버튼을 누르면
                    {
                        if (gaming)             // 게임 중일 때
                            key_Left = true;    // 왼쪽 이동 플래그 true
                        break;
                    }
                case Keys.NumPad6:              // Numpad6 버튼을 누르면
                    {
                        if (gaming)             // 게임 중일 때
                            key_Right = true;   // 오른쪽 이동 플래그 true
                        break;
                    }
                case Keys.Q: //speed up         // Q 버튼을 누르면
                    {
                        if (speed >= 100)       // 토끼의 속도가 100 이상일 때는
                            return;             // 속도를 올리지 않고 return
                        speed += 1;             // 속도가 100 미만이라면 속도 + 1
                        speed_Label.Text = (Convert.ToInt32(speed_Label.Text) + 1).ToString();
                                                // speed를 표시하는 라벨 + 1
                        break;
                    }
                case Keys.W: //speed down       // W 버튼을 누르면
                    {
                        if (speed <= 0)         // 토끼의 속도가 0 이하라면
                            return;             // 속도를 내리지 않고 return
                        speed -= 1;             // 속도가 0 초과라면 속도 -1
                        speed_Label.Text = (Convert.ToInt32(speed_Label.Text) - 1).ToString();
                                                // speed를 표시하는 라벨 - 1
                        break;
                    }
                case Keys.E:                    // E 버튼을 누르면
                    {                           
                        if (Convert.ToInt32(star_Label.Text) >= 1 && !madRabbit) // 스타가 있다는 것을 검사
                        {                       //스타가 있으면
                            player.Stop(0);     // BGM 끄고
                            player.Play(1);     // 화난 토끼 BGM 실행
                            rabbit_Pic.Image = Image.FromFile(Application.StartupPath + @"\Resources\화난토끼.png");
                                                //화난 토끼 이미지로 바꾸고
                            star_Label.Text = (Convert.ToInt32(star_Label.Text) - 1).ToString(); // 스타 1 감소
                            madRabbit = true;   // 화난 토끼인지 플래그 true로 설정
                            mad_timer.Enabled = true;   //3초를 재기 위해 timer 설정
                            mad_timer.Start();          //timer 시작
                        }
                        //스타가 없으면 아무 행동도 하지 않음
                        break;
                    }
            }
        }//KeyDownEvent 끝
        
        private void KeyUpEvent(object sender, KeyEventArgs e)  //KeyEvent 처리함수
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad4:      // Numpad4 버튼을 떼면
                    {
                        key_Left = false;   // 왼쪽 이동 플래그 false
                        break;
                    }
                case Keys.NumPad6:      // Numpad6 버튼을 떼면
                    {
                        key_Right = false;  // 오른쪽 이동 플래그 false
                        break;
                    }
            }
        }

        private void moving_timer_Tick(object sender, EventArgs e)  //타이머가 tick 할 때마다 상태 검사 후 이동
        {
            if (gaming) // 게임 중일 때에만
            {
                if (key_Left && (rabbit_Pic.Left >= 10))    // Numpad4가 눌린 상태이고
                {                                           // 화면 밖으로 나가지 않는 상태 검사
                    rabbit_Pic.Left -= speed;   //왼쪽으로 speed만큼 이동
                }
                if (key_Right && (rabbit_Pic.Right <= Dfield.Width - 10)) // Numpad4가 눌린 상태이고
                {                                                         // 화면 밖으로 나가지 않는 상태 검사
                    rabbit_Pic.Left += speed;   // 오른쪽으로 speed만큼 이동
                }
            }
        }

        private void Drop()     // 화면에 있는 폭탄과 과일 떨어뜨리는 쓰레드
        {
            while (gaming)      // 게임중일 때
            {
                foreach (Pic p in Bombs)    // 화면의 모든 폭탄과 과일에 대해서
                {
                    if (p != null)  // 화면에 표시된 picturebox라면
                    {
                        p.Drop();   //Picturebox를 상속한 Pic안에 있는 Drop 메소드 호출
                    }
                }
                Thread.Sleep(65);   //일정한 간격을 두고 떨어뜨리기 위해 sleep
            }
        }

        private void Eat()  //토끼가 물체를 먹었을 때와, 과일이 땅에 떨어졌을 때 처리해주는 쓰레드
        {
            while (gaming)  //게임중일 때
            {
                for (int i = 0; i < MAX_OBJ_NUMBER; i++)    //모든 폭탄과 과일에 대해서
                {
                    if (Bombs[i] != null)       // 화면에 표시된 오브젝트라면
                    {
                        if (rabbit_Pic.Bounds.IntersectsWith(Bombs[i].Bounds))  //토끼와 닿았을 때
                        {
                            if (Bombs[i].Name == "Bomb" && !madRabbit)  // 화난 토끼 상태가 아니고, 그 오브젝트가 폭탄이라면
                            {
                                Invoke(new MethodInvoker(() =>
                                {
                                    life_Label.Text = (Convert.ToInt32(life_Label.Text) - 1).ToString();    //라이프 -1
                                    if (life_Label.Text == "0") //라이프가 0이라면 게임을 종료한다
                                        GameStop();
                                }));
                                player.PlayNoLoop(3);   //폭탄을 먹었을 때의 효과음 재생
                            }
                            else if (Bombs[i].Name == "Heart")  //오브젝트가 하트라면
                            {
                                Invoke(new MethodInvoker(() => life_Label.Text = (Convert.ToInt32(life_Label.Text) + 1).ToString()));
                                                            // 라이프 + 1
                                player.PlayNoLoop(2);       // 하트를 먹었을 때 효과음 재생
                            }
                            else if (Bombs[i].Name == "Star")   //오브젝트가 별이라면
                            {
                                Invoke(new MethodInvoker(() => star_Label.Text = (Convert.ToInt32(star_Label.Text) + 1).ToString()));
                                                                // 스타 + 1
                                player.PlayNoLoop(2);           // 별을 먹었을 때 효과음 재생
                            }
                            else if (Bombs[i].Name == "Fruit")  //오브젝트가 다른 과일이라면
                            {
                                Invoke(new MethodInvoker(() => score_Label.Text = (Convert.ToInt32(score_Label.Text) + 45).ToString()));
                                                        // 점수 + 45
                            }
                            Invoke(new MethodInvoker(() => Bombs[i].Dispose()));    // 점수, 라이프 등을 처리하고 난 후
                            Bombs[i] = null;                                        // 해당 물체를 없애고, null로 만듦
                        }
                        else if (Bombs[i].mustDisposed)                             // Picturebox를 상속받은 클래스 Pic에서
                        {                                                           // 해당 물체가 화면을 벗어나면 mustDiposed 속성을 true로 만듦
                            if ((Bombs[i].Name == "Fruit") && (Bombs[i].Name != "Bomb"))    //과일일 때
                            {
                                Invoke(new MethodInvoker(() =>
                                {
                                    life_Label.Text = (Convert.ToInt32(life_Label.Text) - 1).ToString();    //과일이 벗어나면 life - 1
                                    if (life_Label.Text == "0")                     // 라이프가 0이면 게임종료
                                        GameStop();
                                }));
                                player.PlayNoLoop(3);       //과일이 땅에 닿았을 때 효과음 재생
                            }
                            Invoke(new MethodInvoker(() => Bombs[i].Dispose()));    // 점수, 라이프 등을 처리하고 난 후
                            Bombs[i] = null;                                        // 해당 물체를 없애고, null로 만듦
                        }
                    }
                }
            }
        }

        // 시작 버튼 클릭
        private void start_Btn_Click(object sender, EventArgs e)
        {
            game_over_Label.Visible = false;    //Game over 표시를 끄고
            Bombs = new Pic[MAX_OBJ_NUMBER];    //폭탄, 과일 배열 할당
            gaming = true;                      //게임중 플래그를 true로 변경

            cloud_Pic.Visible = true;           //구름을 보이게 하고,

            moving_timer.Enabled = true;        //이동 타이머 작동
            moving_timer.Start();

            score_timer.Enabled = true;         //점수 타이머 작동
            score_timer.Start();

            cloud_Timer.Enabled = true;         //구름 이동 타이머 작동
            cloud_Timer.Start();

            generateTimer.Enabled = true;       //폭탄, 과일 발생 타이머 작동
            generateTimer.Start();

            drop_Thread = new Thread(new ThreadStart(Drop));    //떨어뜨리는 쓰레드 시작
            drop_Thread.Start();

            eat_Thread = new Thread(new ThreadStart(Eat));      //물체 먹는 쓰레드 시작
            eat_Thread.Start();

            this.start_Btn.Enabled = false;      //스타트버튼 비활성화
            this.high_Btn.Enabled = false;       //게임 중에는 하이스코어 보는 버튼 비활성화

            player = new BGMPlayer();           //BGM 재생 클래스 인스턴스 생성
            player.UpdateVolume(100);
            player.Play(0);                     //BGM 재생
        }

        private void GameStop() //게임을 종료하는 메소드
        {
            int scoreSave = Convert.ToInt32(score_Label.Text);  //하이스코어 저장을 위해 int형 변수에 현재 점수 할당
            try
            {
                player.Stop();                  //모든 BGM과 효과음을 멈추고
                player.PlayNoLoop(4);           //Game Over 효과음 재생

                game_over_Label.Visible = true; //게임 오버 라벨 보이게 함

                cloud_Pic.Visible = false;      //구름을 안보이게 설정

                cloud_Timer.Stop();             //타이머들 멈추고, 해제
                cloud_Timer.Dispose();

                cloud_Timer.Enabled = false;
                score_timer.Stop();

                score_timer.Dispose();
                score_timer.Enabled = false;

                moving_timer.Stop();
                moving_timer.Dispose();
                moving_timer.Enabled = false;

                generateTimer.Stop();
                generateTimer.Interval = 200;   //레벨에 따라 변경된 Interval 초기화
                generateTimer.Dispose();
                generateTimer.Enabled = false;

                start_Btn.Enabled = true;       //비활성화된 버튼들을
                high_Btn.Enabled = true;        //다시 활성화

                life_Label.Text = "10";
                star_Label.Text = "2";
                score_Label.Text = "0";
                level_Label.Text = "1";
                speed_Label.Text = "25";        //라이프, 별 등 모두 게임 시작 전 상태로 변경
                key_Left = false;               
                key_Right = false;              //이동 플래그 초기화(안해주면 다음 게임 시작할 때 토끼가 자동으로 이동함
                cloudSpeed = 5;                 //레벨에 따라 변경된 구름의 속도 초기화
                Maxp = 15;                      //폭탄, 과일 발생 확률 초기화
                speed = 10;                     //토끼의 속도 초기화

                rabbit_Pic.Location = new Point(0, 350);    //토끼를 초기 위치로 이동
            }
            catch { }
            finally
            {
                try
                {
                    drop_Thread.Abort();        //쓰레드 종료
                }
                catch { }
                finally //예외가 발생해도 다음 행동을 실행할 수 있도록 try-catch-finally문 중첩으로 예외 처리
                {
                    try
                    {
                        eat_Thread.Abort();
                    }
                    catch { }
                    finally
                    {
                        try
                        {
                            for (int i = 0; i < MAX_OBJ_NUMBER; i++)    //화면에 표시된 모든 폭탄과 과일 지우고 배열 초기화
                            {
                                if (Bombs[i] != null)
                                {
                                    Bombs[i].Dispose();
                                    Bombs[i] = null;
                                }
                            }
                        }
                        catch { }
                        finally
                        {
                            savescore s = new savescore();              //하이스코어 입력 폼 실행
                            s.Owner = this;
                            s.score = scoreSave;
                            s.ShowDialog();                             //Modal로 하이스코어 폼 실행
                        }
                    }
                }
            }
        }

        private void manual_Btn_Click(object sender, EventArgs e)   //매뉴얼 버튼 클릭 시
        {
            Manual manual = new Manual();
            manual.Show();                         //메뉴얼폼 띄우기
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)  //폼이 닫히면
        {                                                                       //쓰레드들 없애주는 메소드
            try
            {
                if (drop_Thread.IsAlive)
                    drop_Thread.Abort();
            }
            catch
            {

            }
            finally
            {
                try
                {
                    if (eat_Thread.IsAlive)
                        eat_Thread.Abort();
                }
                catch { }
            }
        }

        private void exit_Btn_Click(object sender, EventArgs e)//Exit 버튼 클릭 시
        {
            this.Close();// 창을 닫음
        }

        private void score_timer_Tick(object sender, EventArgs e) //점수에 따라 난이도를 조절하는 타이머
        {
            if (Convert.ToInt32(level_Label.Text) < 5)          //최대 레벨은 5
            {
                level_Label.Text = (Convert.ToInt32(score_Label.Text) / 450 + 1).ToString();//450마다 레벨 증가
                cloudSpeed = 5 + 2 * (Convert.ToInt32(level_Label.Text));   //레벨마다 구름의 속도 증가(최대 15)
                generateTimer.Interval = 200 - 10 * (Convert.ToInt32(level_Label.Text));//레벨마다 개체가 떨어지는 빈도 증가
                Maxp = 9 - Convert.ToInt32(level_Label.Text);//레벨에 따라 개체가 떨어질 확률 증가
            }
        }

        private void mad_timer_Tick(object sender, EventArgs e)//화난 토끼 모드 활성화시 3초를 재주고 돌아가는 기능
        {//3초가 지나면
            madRabbit = false;  //화난토끼 플래그를 false로 만들고
            rabbit_Pic.Image = Image.FromFile(Application.StartupPath + @"\Resources\토끼.png");//이미지를 바꾸고
            mad_timer.Stop();
            mad_timer.Enabled = false;//타이머를 멈춘 후
            player.Stop(1);//화난토끼 BGM을 멈추고
            player.Play(0);//다시 원래의 BGM 재생
        }

        private void cloud_Timer_Tick(object sender, EventArgs e)//구름을 움직이는 타이머
        {
            if (gaming)//게임중일 때
            {
                Random rand = new Random();
                if (rand.Next(1, 40) == 1 || cloud_Pic.Location.X <= 10 || cloud_Pic.Location.X + cloud_Pic.Width >= Dfield.Width - 10)
                {//구름을 방향을 바꾸는 경우 : 1/40 확률 + 구름이 양 끝에 부딪힐 때
                    if (cloudDirection)
                        cloudDirection = false;
                    else
                        cloudDirection = true;
                }
                if (cloudDirection && (cloud_Pic.Left >= 10))   //true시 왼쪽 이동
                {
                    cloud_Pic.Left -= cloudSpeed;
                }
                if (!cloudDirection && (cloud_Pic.Right <= Dfield.Width - 10))  //false시 오른쪽 이동
                {
                    cloud_Pic.Left += cloudSpeed;
                }
            }

        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (player != null)
                player.Unload();    //폼이 닫히면서 bgmplayer가 사용한 리소스를 해제한다.
        }

        private void spdDown_Btn_Click(object sender, EventArgs e)  //keydown event의 w와 동일함
        {
            if (speed <= 0)
                return;
            speed -= 1;
            speed_Label.Text = (Convert.ToInt32(speed_Label.Text) - 1).ToString();
        }

        private void spdUp_Btn_Click(object sender, EventArgs e)    //keydown event의 q와 동일함
        {
            if (speed >= 100)
                return;
            speed += 1;
            speed_Label.Text = (Convert.ToInt32(speed_Label.Text) + 1).ToString();
        }

        private void high_Btn_Click(object sender, EventArgs e)     //하이스코어 버튼을 클릭시
        {
            savescore s = new savescore();                          //하이스코어를 보여주는
            s.Highscore_Btn = true;                                 //savescore 폼 생성 후
            s.ShowDialog();                                         //modal로 실행
        }

        private void generateTimer_Tick(object sender, EventArgs e) //랜덤으로 폭탄, 과일을 발생시키는 타이머
        {
            try
            {
                    Random rand = new Random();
                    if (gaming) //게임 중일 때
                    {
                        int randNum = rand.Next(1, Maxp);   //난수 발생 Maxp는 난이도를 위해 고정값으로 하지 않음

                        if (randNum == 1)
                        {
                            Pic Obj = new Pic();
                            Obj.Name = "Bomb";  //폭탄이면 이름을 Bomb로 설정--> 후에 먹을 때 이것으로 개체를 구분
                            Obj.BackColor = Color.Transparent;
                            Obj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            Obj.Size = new System.Drawing.Size(dropItems_Size, dropItems_Size);
                            Obj.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_bomb.png");
                            Obj.Location = cloud_Pic.Location;      //이미지를 생성후 속성을 설정하고
                            Dfield.Controls.Add(Obj);               //패널에 해당 컨트롤을 추가함
                            Bombs[GetIndex(Bombs)] = Obj;           //그 후 그 컨트롤을 떨어뜨리기 위해 배열에 저장
                        }

                        if (randNum == 2)
                        {
                            Pic fruit = new Pic();
                            fruit.Name = "Fruit";                   //이름을 과일로 설정
                            fruit.BackColor = Color.Transparent;
                            fruit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            fruit.Size = new System.Drawing.Size(dropItems_Size, dropItems_Size);
                            fruit.Location = cloud_Pic.Location;
                            switch (rand.Next(1, 11))   //이미지를 랜덤으로 설정하는 부분
                            {
                                case 1:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_apple.png");
                                        break;
                                    }
                                case 2:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_cherry.png");
                                        break;
                                    }
                                case 3:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_grapes.png");
                                        break;
                                    }
                                case 4:
                                    {
                                        fruit.Name = "Heart";   //이미지가 하트라면, 이름을 하트로 하여 하트를 구분할 수 있게 함
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_heart.png");
                                        break;
                                    }
                                case 5:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_kiwi.png");
                                        break;
                                    }
                                case 6:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_orange.png");
                                        break;
                                    }
                                case 7:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_pear.png");
                                        break;
                                    }
                                case 8:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_pineapple.png");
                                        break;
                                    }
                                case 9:
                                    {
                                        fruit.Name = "Star";    //이미지가 별이라면, 이름을 별로 하여 별을 구분할 수 있게 함
                                    fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_star.png");
                                        break;
                                    }
                                case 10:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_strawberry.png");
                                        break;
                                    }
                                case 11:
                                    {
                                        fruit.Image = Image.FromFile(Application.StartupPath + @"\Resources\f_watermelon.png");
                                        break;
                                    }
                            }
                            fruit.Location = cloud_Pic.Location;    //현재 구름의 위치로 위치를 잡음
                            Dfield.Controls.Add(fruit);             //패널에 추가
                            Bombs[GetIndex(Bombs)] = fruit;         //배열에 추가
                        }
                }

            }
            catch (Exception)
            {

            }
        }
    }

    public class Pic : PictureBox   //각 picturebox별로 가속도를 관리하기 위해
    {
        public int accel;   //--> 각 개체별로 가속도를 관리
        public bool mustDisposed = false;   //물체가 화면 밖으로 넘어가면 mustDisposed를 true로 바꿈

        public Pic()
        {
            this.accel = 0;         //생성할 때 가속도 0
        }

        public void Drop()      //Drop쓰레드에서 떨어뜨려주는 함수
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.Top += accel;
                    if (this.Location.Y > 600)//과일이 땅에 떨어지면
                        mustDisposed = true;  //플래그를 true로 바꿔서 dispose되도록 함--> eat 쓰레드
                    this.accel += 2;    //가속도를 증가 2, 4, 6 .... 계속 일정한 가속도로 떨어짐
                }));
            }
            catch (Exception e)
            {

            }
        }
    }
}