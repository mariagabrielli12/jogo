int[,] jogo = new int[4, 4];
int[,] tela = new int[4, 4];

//Para criar números aleatórios
Random gerador = new Random();

for (int i = 1; i <= 8; i++) //Atribui os pares de números às posições
{
    //Escolhe a posição do primeiro número do par
    int lin, col;
    for (int j = 0; j < 2; j++)
    {
        do
        {
            lin = gerador.Next(0, 4);
            col = gerador.Next(0, 4);

        } while (jogo[lin, col] != 0);
        jogo[lin, col] = i;
    }
}

int acertos = 0;
do
{
    for( int j = 0; j< 4; j++)
    {
        Console.Write("  {0} ", j + 1);
    }
    Console.WriteLine("\n -----------------");
    for (int i = 0; i < 4; i++)
    {
        Console.Write("{0} |", i +1);
        for (int j = 0; j < 4; j++)
        {
            Console.Write("{0} |", tela[i, j]);
        }
        Console.WriteLine("\n ----------------");
    }

    Console.WriteLine();
   
    int lin1, col1;
    do {
        //Pedir as posições do primeiro número
        Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
        lin1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
        col1 = int.Parse(Console.ReadLine());

        lin1--;
        col1--;
    }while(lin1 <0 || lin1 >= 4 || col1 >= 4 || col1 <0);


    tela[lin1, col1] = jogo[lin1, col1];

    Console.WriteLine("\n -----------------") ;

    for (int i = 0; i < 4; i++)
    {
        Console.Write("{0} |", i + 1);
        for (int j = 0; j < 4; j++)
        {
            Console.Write("{0} |", tela[i, j]);
        }
        Console.WriteLine("\n ---------------------");
    }
    Console.WriteLine();

    int lin2, col2;

    do {

        //Pedir as posições do segundo número
        Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
        lin2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
        col2 = int.Parse(Console.ReadLine());
         
        lin2--;
        col2--;

    }while(lin2 < 0 || lin2 >= 4|| col2 >= 4 || col2 < 0);

    tela[lin2, col2] = jogo[lin2, col2];

    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write("{0} |", tela[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();

    //Em caso de acerto, a matriz tela permanece como está.
    //Em caso de erro, precisamos voltar as posições para zero.
    if (jogo[lin1, col1] != jogo[lin2, col2])
    {
        tela[lin1, col1] = 0;
        tela[lin2, col2] = 0;
    }
    else
    {
        acertos++;
    }
    Console.WriteLine("Digite 0 para sair ou qualquer outro número para continuar");
    int n = int.Parse(Console.ReadLine());

    if(n == 0)

        break;

} while (acertos < 8);