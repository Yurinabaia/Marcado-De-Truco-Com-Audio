using System;
using Plugin.SimpleAudioPlayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using App1Truco;

namespace TrucoAPP
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer player;
        public MainPage()
        {
            InitializeComponent();
            BOTDOIS.Clicked += BotaoDois;   
            BOTTRUCO.Clicked += BotaoTruco;
            BOTSEIS.Clicked += BotaoSeis;
            BOTNOVE.Clicked += BotaoNove;
            BOTDOZE.Clicked += BotaoDoze;
            BOTZERO.Clicked += BotaoZero;
            BOTEQUIPEA.Clicked += BotaoEquipeA;
            BOTEQUIPEB.Clicked += BotaoEquipeB;

        }
        private int ValorDoJogo = 0;
        private int BotA = 0;
        private int BotB = 0;
        private int tentos = 0;
        private void BotaoDois(Object sender, EventArgs args)
        {
            ValorDoJogo = 2;
            ValendoJogo.Text = "Valor do tento da partida " + ValorDoJogo.ToString();
        }
        private void BotaoTruco(Object sender, EventArgs args)
            {
            string[] musicas = new string[3];
            musicas[0] = "Zoeira.mp3";
            musicas[1] = "seis9.mp3";
            musicas[2] = "nove8.mp3";
            





            int cont = 0;
            if (BotA == 10 || BotB == 10)
            {
                DisplayAlert("Erro", "Não pode pedir truco na mão de 10", "OK");
                cont = 1;
            }
            if (cont == 0)
            {
                ValorDoJogo = 4;
                ValendoJogo.Text = "Valor do tento da partida " + ValorDoJogo.ToString();
                var stream = GetStreamFromFile(musicas[Randomizer.Next()]);
                var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                audio.Load(stream);
                audio.Play();
                tentos = 4;
            }
        }
        private void BotaoSeis(Object sender, EventArgs args)
        {

            if (tentos == 4)
            {
                ValorDoJogo = 8;
                ValendoJogo.Text = "Valor do tento da partida " + ValorDoJogo.ToString();
                var stream = GetStreamFromFile("seis9.mp3");
                var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                audio.Load(stream);
                audio.Play();
                tentos = 8;
            }
            else 
            {
                DisplayAlert("Erro", "Ainda não foi pedido Truco", "OK");
            }
        }
        private void BotaoNove(Object sender, EventArgs args)
        {
            if (tentos == 8)
            {
                ValorDoJogo = 10;
                ValendoJogo.Text = "Valor do tento da partida " + ValorDoJogo.ToString();
                var stream = GetStreamFromFile("nove8.mp3");
                var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                audio.Load(stream);
                audio.Play();
                tentos = 10;
            }
            else 
            {
                DisplayAlert("Erro", "Ainda não foi pedido Seis", "OK");
            }
        }
        private void BotaoDoze(Object sender, EventArgs args)
        {
            if (ValorDoJogo == 10)
            {
                ValorDoJogo = 12;
                ValendoJogo.Text = "Valor do tento da partida " + ValorDoJogo.ToString();
                var stream = GetStreamFromFile("doze8.mp3");
                var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                audio.Load(stream);
                audio.Play();
            }
            else 
            {
                DisplayAlert("Erro", "Ainda não foi pedido Nove", "OK");
            }
        }
        private void BotaoZero(Object sender, EventArgs args)
        {
            ValorDoJogo = 0;
            BotA = 0;
            BotB = 0;
            ValendoJogo.Text = "Bem vindo ao marcado de truco do Nabaia";
            LABELEQUIPEA.Text = "Pontos da equipe A = 0";
            LABELEQUIPEB.Text = "Pontos da equipe B = 0";

        }
        private void BotaoEquipeA(Object sender, EventArgs args)
        {
            BotA += ValorDoJogo;
            if (ValorDoJogo != 0 && BotA <= 10)
            {
                LABELEQUIPEA.Text = "Pontos da equipe A = " + BotA.ToString();
                ValorDoJogo = 0;
                ValendoJogo.Text = "Bem vindo ao marcado de truco do Nabaia";

            }
            else if (ValorDoJogo == 0)
            {
                DisplayAlert("Error", "Click no botao da quantidade de tentos", "OK");
            }
            else if (BotA > 10)
            {
                DisplayAlert("Parabéns", "Equipe A ganhou o jogo", "OK");
                ValorDoJogo = 0;
                BotA = 0;
                BotB = 0;
                ValendoJogo.Text = "Bem vindo ao marcado de truco do Nabaia";
                LABELEQUIPEA.Text = "Pontos da equipe A = 0";
                LABELEQUIPEB.Text = "Pontos da equipe B = 0";
            }
        }
        private void BotaoEquipeB(Object sender, EventArgs args)
        {
            BotB += ValorDoJogo;
            if (ValorDoJogo != 0 && BotB <= 10)
            {
                LABELEQUIPEB.Text = "Pontos da equipe B = " + BotB.ToString();
                ValorDoJogo = 0;
                ValendoJogo.Text = "Bem vindo ao marcado de truco do Nabaia";

            }
            else if (ValorDoJogo == 0)
            {
                DisplayAlert("Error", "Click no botao da quantidade de tentos", "OK");
            }
            else if (BotB > 10)
            {
                DisplayAlert("Parabéns", "Equipe B ganhou o jogo", "OK");
                ValorDoJogo = 0;
                BotA = 0;
                BotB = 0;
                ValendoJogo.Text = "Bem vindo ao marcado de truco do Nabaia";
                LABELEQUIPEA.Text = "Pontos da equipe A = 0";
                LABELEQUIPEB.Text = "Pontos da equipe B = 0";
            }
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("App1Truco." + filename);

            return stream;
        }
        private void BotaoA(object sender, EventArgs args) 
        {
        
        }
    }
}
