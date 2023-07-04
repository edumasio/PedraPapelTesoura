using System;

class Program
{
    static int Rodadas;
    public static void Main(string[] args)
    {
        start();

    }
    public static void start()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("Digite \"1\" para começar");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {
            Console.Clear();
            DesenhaCabecalho(3);
            Console.WriteLine("Opção invalida. Digite 1 Para começar");
            iniciar = Int32.Parse(Console.ReadLine());

        }
        DefineRodadas();

    }
    public static void DesenhaCabecalho(int linhasExtras)
    {

        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("*   Pedra, Papel ou Tesoura   *");
        Console.WriteLine("*******************************");
        for (int i = 0; i < linhasExtras; i++) ;
        Console.WriteLine("\n");

    }
    public static void DefineRodadas()
    {

        DesenhaCabecalho(3);
        Console.WriteLine("Quantas rodadas você quer jogar ??? 3, 5 ou 7");
        Rodadas = Int32.Parse(Console.ReadLine());

        while (Rodadas != 3 && Rodadas != 5 && Rodadas != 7)
        {
            DesenhaCabecalho(3);

            Console.WriteLine("você digitou um valor invalido. Escolha entre os numeros 3, 5 ou 7");
            Rodadas = Int32.Parse(Console.ReadLine());



        }
        ControlaRodadas();
    }
    public static void ControlaRodadas()
    {

        int RodadaAtual = 1;
        int PontosDoUsuario = 0;
        int PontosDoPrograma = 0;
        bool fimDeJogo = false;


        while (fimDeJogo != true)
        {
            DesenhaCabecalho(0);
            Console.WriteLine("          Rodada " + RodadaAtual.ToString() + "/" + Rodadas.ToString() + "           ");
            Console.WriteLine();
            Console.WriteLine("User: " + PontosDoUsuario.ToString() + " pontos   | CPU: " + PontosDoPrograma.ToString() + " pontos");


            switch (ExibeRodadas())
            {
                case 0:
                    break;
                case 1:
                    PontosDoUsuario++;
                    RodadaAtual++;
                    if (PontosDoUsuario > Rodadas / 2)
                    {
                        Console.WriteLine("O HOMEN VENCEU A MAQUINA");
                        fimDeJogo = true;
                    }
                    break;
                case 2:

                    PontosDoPrograma++;
                    RodadaAtual++;
                    if (PontosDoPrograma > Rodadas / 2)
                    {
                        Console.WriteLine("A MAQUINA VENCEU O HOMEN");
                        fimDeJogo = true;
                    }
                    break;
            }
            if (fimDeJogo == true)
            {
                DesenhaCabecalho(3);
                if (PontosDoUsuario > PontosDoPrograma)
                {
                    Console.WriteLine("parabens voce ganhou da maquina");
                }
                else
                {
                    Console.WriteLine("não foi dessa vez");
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite qualquer tecla para recomeçar p jogo");
                Console.ReadLine();
                start();
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    start();
                }
            }
        }
    }
    public static int ExibeRodadas()
    {


        string escolhaDoUsuario; //armazena qual das opções o usuário escolheu
        string escolhaDoPrograma; //armazena qual da opções o computador sorteou
        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };
        //O Usuário deve escolher uma das opções. Lembrar de deixar claro quais são as opções
        Console.WriteLine();
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

        //O programa deve exibir q uem ganhou, lembrando que Papel ganha de Pedra, Pedra ganha de Tesoura e Tesoura ganha de Papel
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
            Console.WriteLine("O HOMEN VENCEU A MAQUINA !");
            return 1;

        }
        else
        {
            Console.WriteLine("A MAQUINA VENCEU O HOMEN !");
            return 2;
        }
    }
}