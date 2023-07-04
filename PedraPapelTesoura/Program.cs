using System;

class Program
{
    static int rodadas;
    public static void Main(string[] args)
    {

        Start();

    }
    public static void Start()
    {
        Desenha_cabecalho(3);
        Console.WriteLine("Digite \"1\" para começar");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {

            Desenha_cabecalho(3);
            Console.WriteLine("Opção Inválida! Digite 1 para começar");
            iniciar = Int32.Parse(Console.ReadLine());
        }
        Define_rodadas();
    }
    public static void Desenha_cabecalho(int linhas_extras)
    {
        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("*   Pedra, Papel ou Tesoura   *");
        Console.WriteLine("*******************************");
        for (int i = 0; i < linhas_extras; i++)
        {
            Console.WriteLine("\n");

        }
    }
    public static void Define_rodadas()
    {


        Desenha_cabecalho(3);
        Console.WriteLine("Quantas rodadas você quer jogar? 3, 5 ou 7?");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {

            Desenha_cabecalho(3);
            Console.WriteLine("Você digitou um valor inválido! Escolha as opções 3, 5 ou 7?");
            rodadas = Int32.Parse(Console.ReadLine());
        }
        Controla_rodadas();
    }
    public static void Controla_rodadas()
    {
        int rodada_atual = 1;
        int pontos_usuario = 0;
        int pontos_maquina = 0;
        bool fim_de_jogo = false;

        while (fim_de_jogo != true)
        {
            Desenha_cabecalho(0);
            Console.WriteLine("          Rodada " + rodada_atual.ToString() + "/"
  + rodadas.ToString() + "           ");
            Console.WriteLine();
            Console.WriteLine("User: " + pontos_usuario.ToString() + " pontos  |   CPU: " + pontos_maquina.ToString() + " pontos");

            switch (Exibe_rodada())
            {
                case 0:
                    break;
                case 1:
                    pontos_usuario++;
                    rodada_atual++;
                    if (pontos_usuario > rodadas / 2)
                    {
                        Console.WriteLine("Usuário venceu");
                    }
                    break;
                case 2:
                    pontos_maquina++;
                    rodada_atual++;
                    if (pontos_usuario > rodadas / 2)
                    {
                        Console.WriteLine("Maquina venceu");
                        fim_de_jogo = true;
                    }
                    break;
            }


            if (fim_de_jogo == true)
            {
                Desenha_cabecalho(3);
                if (pontos_usuario > pontos_maquina)
                {
                    Console.WriteLine("Parabéns!!!! Você ganhou!!!");

                }
                else
                {
                    Console.WriteLine("Não foi dessa vez!");

                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite qualquer tecla para continuar");
                Console.ReadLine();
                Start();
            }
            else
            {
                Console.WriteLine("Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    Start();
                }
            }
        }
    }
    public static int Exibe_rodada()
    {
        //Algumas variáveis já estão criadas
        string escolhaDoUsuario; //armazena qual das opções o usuário escolheu
        string escolhaDoPrograma; //armazena qual da opções o computador sorteou
        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
        };
        //O Usuário deve escolher uma das opções. Lembrar de deixar claro quais são as opções
        Console.WriteLine("Escolha uma das opções: Pedra, Papel ou Tesoura?");
        escolhaDoUsuario = Console.ReadLine().ToUpper();
        while (escolhaDoUsuario != "PEDRA" && escolhaDoUsuario != "PAPEL" && escolhaDoUsuario != "TESOURA")
        {
            Console.WriteLine("Você fez uma escolha inválida. Digite novamente: Pedra, Papel ou Tesoura?");
            escolhaDoUsuario = Console.ReadLine().ToUpper();
        }
        //O Computador deve escolher uma das opções e o programa deve exibir qual foi essa escolha
        Random rand = new Random();
        int sorteio = rand.Next(opcoes.Length);
        escolhaDoPrograma = opcoes[sorteio];
        Console.WriteLine("A escolha do computador foi: " + escolhaDoPrograma);

        //O programa deve exibir quem ganhou, lembrando que Papel ganha de Pedra, Pedra ganha de Tesoura e Tesoura ganha de Papel
        if (escolhaDoUsuario == escolhaDoPrograma)
        {
            Console.WriteLine("Deu empate");
            return 0;
        }
        else if (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else
        {
            Console.WriteLine("Que pena! Quem venceu foi o computador!");
            return 2;
        }
    }
}

