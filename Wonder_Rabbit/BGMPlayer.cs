using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FMOD;
using System.Windows.Forms;

namespace Wonder_Rabbit
{
    public class BGMPlayer  //유저의 추가 기능 : BGM, 효과음 삽입
    {
        public const int NUM_SONGS = 5;
        //1. 일반 배경음 2. 화난 토끼 배경음 3. 폭탄 효과음 4. 하트, 별 효과음 5. 게임 오버 효과음
        public const int RECORD_CHANNEL = NUM_SONGS;            //이번 소프트웨어실습 3의
        public const int PRESET_CHANNEL = NUM_SONGS + 1;        //프로젝트를 진행한 클래스를 이용한 것
        public bool recordPlaying = false;                      //이 과제에서는 필요 없는 변수

        public FMOD.System FMODSystem;
        public FMOD.Channel[] Channel;
        public FMOD.Sound[] Songs;

        public static BGMPlayer _instance;

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);  //dll을 import 해주고

        public static void Init()   //운영 체제에 따라 dll 선택
        {
            if (Environment.Is64BitProcess)
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\64\\fmod.dll"));
            else
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\32\\fmod.dll"));

            _instance = new BGMPlayer();
        }

        public void Unload()
        {
            FMODSystem.release();   //리소스 해제
        }

        public BGMPlayer()//생성자에서 음악 파일들을 로드함
        {
            FMOD.Factory.System_Create(out FMODSystem);

            FMODSystem.setDSPBufferSize(1024, 10);
            FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);

            Songs = new FMOD.Sound[NUM_SONGS];
            Channel = new FMOD.Channel[NUM_SONGS];

            LoadSong(0, "BGM");
            LoadSong(1, "MAD");
            LoadSong(2, "FRUIT");
            LoadSong(3, "BOMB");
            LoadSong(4, "GAMEOVER");
        }

        public void LoadSong(int songId, string name)
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\BGM\" + name + ".wav", FMOD.MODE.DEFAULT, out Songs[songId]);
            if (r != RESULT.OK)         //song을 load하는 기능
                MessageBox.Show("Load ERR");
        }

        public bool IsPlaying(FMOD.Channel channel) //채널이 play중인지 return하는 함수
        {
            bool returnbool = false;
            channel.isPlaying(out returnbool);
            return returnbool;
        }

        public void Play(int songId)    //해당 songId에 해당하는 곡을 play
        {
            if (songId >= 0 && songId < NUM_SONGS && Songs[songId] != null)
            {
                FMODSystem.playSound(Songs[songId], null, false, out Channel[songId]);
                Channel[songId].setMode(FMOD.MODE.LOOP_NORMAL); //끝나도 다시 시작하도록 loop로 설정(배경음)
            }
        }

        public void PlayNoLoop(int songId)  //play 메소드와 같으나 loop 없이 플레이하기 위함(효과음)
        {
            if (songId >= 0 && songId < NUM_SONGS && Songs[songId] != null)
            {
                FMODSystem.playSound(Songs[songId], null, false, out Channel[songId]);
                Channel[songId].setMode(FMOD.MODE.DEFAULT);
            }
        }

        public void UpdateVolume(float Value)   //처음 플레이어 로드 시 볼륨을 설정해주는 메소드
        {
            for (int i = 0; i < NUM_SONGS; i++)
                if (Channel[i] != null)
                    Channel[i].setVolume(Value / 100);
        }

        public void Stop()                  //모든 채널을 멈추는 메소드
        {
            for (int i = 0; i < NUM_SONGS; i++)
                if (Channel[i] != null)
                    Channel[i].stop();
        }

        public void Stop(int i)         //i의 해당 채널만 멈추는 메소드( ex)화난 토끼 기능 사용시 배경음만 stop 등 )
        {
                if (Channel[i] != null)
                    Channel[i].stop();
        }
    }
}
