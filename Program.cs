using System;
using System.Linq;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using static MotivationBuddy.Menus;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


namespace MotivationBuddy
{
    internal class Program
    {

        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }
        
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        


        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Motivation buddy loaded!", System.Drawing.Color.Violet);
            Chat.Say("/all Good luck and have Fun!");

            Menus.CreateMenu();
            Game.OnTick += Game_OnTick;
            Game.OnNotify += OnGameNotify;
            Game.OnEnd += Game_OnEnd;
        }

        private static void Game_OnEnd(EventArgs args)
        {
            Chat.Say("Good game, I had much fun!");
        }

        private static void Game_OnTick(EventArgs args)
        {
        }

        internal static void OnGameNotify(GameNotifyEventArgs args)
        {
            var Sender = args.NetworkId;

            var Ally = EntityManager.Heroes.Allies.FirstOrDefault(e => e.HealthPercent > 20);
            var AllyD = EntityManager.Heroes.Allies.FirstOrDefault(e => e.HealthPercent < 30);
            var AllyK = EntityManager.Heroes.Allies.LastOrDefault();

            if (FirstMenu["EnableM"].Cast<CheckBox>().CurrentValue)
            {
                switch (args.EventId)
                {
                    case GameEventId.OnChampionKill:
                        if ((Sender == AllyK.NetworkId || Sender == AllyD.NetworkId ) && Sender != myhero.NetworkId)
                        {
                            string[] Motivation1 = { "Good Job!", "Nice man", "really nice", "well done", "well played", "gj", "wp", "gj wp", "well done", "well done mate", "nice", "nice play", "You did good there", "let's push", "good job", "nice work", "good play there bro", "we are going to win this", "we will win" };

                            Random RandName = new Random();
                            string Temp1 = Motivation1[RandName.Next(0, Motivation1.Length)];

                            Core.DelayAction(() => Chat.Say(Temp1), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        if (Sender == myhero.NetworkId)
                        {
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Player.DoEmote(Emote.Laugh);

                        }
                        break;
                    case GameEventId.OnChampionDie:
                        if ((Sender == AllyD.NetworkId || Sender == AllyK.NetworkId) && Sender != myhero.NetworkId)
                        {
                            string[] Motivation2 = { "Next time you get him!", "Nice try, next time maybe", "Don't get greedy", "Be less agressive", "Don't lose motivation", "Don't give up", "bad luck", "come on let's team fight" };

                            Random RandName = new Random();
                            string Temp2 = Motivation2[RandName.Next(0, Motivation2.Length)];

                            Core.DelayAction(() => Chat.Say(Temp2), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        break;
                }
            }
            if (FirstMenu["EnableT"].Cast<CheckBox>().CurrentValue)
            {
                var Enemy = EntityManager.Heroes.Enemies.LastOrDefault(e => e.HealthPercent < 30 && !e.IsDead);
                var EnemyD = EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead);
                var EnemyDD = EntityManager.Heroes.Enemies.First();
                var EnemyDDD = EntityManager.Heroes.Enemies.Last();





                switch (args.EventId)
                {
                    case GameEventId.OnChampionDie:
                        if (Sender == Enemy.NetworkId || Sender == EnemyD.NetworkId || Sender == EnemyDD.NetworkId || Sender == EnemyDDD.NetworkId || Sender != myhero.NetworkId)
                        {
                            string[] Tilt2 = { "/all As pessoas boas devem amar seus inimigos", "/all Nunca devemos envergonharmo-nos das nossas próprias lágrimas", "/all vou mandando um beijinho para a filhinha e pra a vovó. Só não posso esquecer da minha éguinha Pocotó", "/all Não zombe de masturbação. É sexo com alguém que eu amo", "/all Um líder carismático, solícito e solidário, é um líder que INSPIRA e motiva.", "/All A vida passa e eu passrinho", "/all Se algo é difícil de fazer, então não vale a pena ser feito!", "/all nunca fui um homem muito religioso mas, se estiver aí em cima, por favor, me salve Super-Homem", "/all A culpa é minha e eu coloco ela em quem eu quiser!", "/All Álcool... A causa e solução de todos os problemas.", "/All Eu não estava mentindo! Estava escrevendo ficção com a boca", "/all Existe três frases curtas que levarão sua vida adiante: 'Não diga que fui eu!', 'Oh, boa idéia, chefe!' e 'Já estava assim quando cheguei'", "/all Chorar não vai trazer de volta seu cão, a não ser que suas lágrimas tenham cheiro de ração.", "/all Nunca diga qualquer coisa a não ser que tenha certeza que todo mundo pensa o mesmo.", "/all A TV me respeita. Ela ri comigo e não de mim.", "/all Eu nuca peço desculpas. Sinto muito, mas é assim que eu sou...", "/all Troque seu coração por um fígado, assim você bebe mais e se apaixona menos", "/all Para mentir, apenas duas coisas são necessárias: alguém que minta e alguém que escute a mentira", "/all Existem três jeitos de fazer as coisas: o jeito certo, o jeito errado, e o meu jeito, que é igual ao jeito errado, só que mais rápido.", "/all Tentar é o primeiro passo rumo ao fracasso", "/all lembre-se, se algo der errado, culpe o cara que não sabe falar inglês.", "/all É melhor ver coisas do que fazer coisas", "/all Se alguma coisa está difícil de ser feita, é porque não é para ser feita", "/all A iniciativa é o primeiro passo para o fracasso", "/all As respostas para todos os problemas da vida não estão no fundo de uma garrafa... estão na TV", "/all O amor é feito só para pessoas jovens e bonitas!", "/all O casamento é o caixão, os filhos são os pregos", "/all Ao contrário do amor, o respeito não pode ser comprado", "/all não beba água... os peixes transam nela", "/all vc pode ter todo o dinheiro do mundo, mas eciste algo que jamais poderá comprar: Um dinissauro", "/all Lembre-se, beber é algo só pra adultos... e crianças com carteiras de identidade falsa", "/all Se um dia você perder o controle, levante-se e troque o canal manualmente", "/all Se um dia quem você ama lhe trair, e você pensar em se jogar de um prédio, lembre-se: você tem chifres, não asas", "/all Mulher é igual a cerveja: cheira bem, tem boa aparência, você passaria por cima da sua mãe pra ter uma! E logo vai querer outra", "/all Preguiça é o ato de descansar, antes de estar cansado", "/all A fé remove montanhas... dinamite então nem se fala", "/all Lembre-se, se o sonho acabou... ainda há o pão doce", "/all não acredite em duendes, eles mentem muito", "/all É fácil reprovar uma idéia, difícil é ter uma", "/all Não importa o quão bom você é em alguma coisa, existem mais ou menos 1 milhão de pessoas melhores q você fazendo a mesma coisa", "/all Passei a detestar a minha própria criação! Agora eu sei como Deus se sente", "/all Comemorem o que têm em comum. Uns não comem porco, outros não comem crustáceos, mas todos adoramos galinha", "/all Crianças, vocês tentaram e falharam miseravelmente. A lição que aprenderam é: nunca tentem", "/all As pessoas inventam estatísticas para provar qualquer coisa. 40% das pessoas sabem disso", "/all em terra de bebado, alcool em gel eh patê", "/all Trate os outros da maneira que eles te ferram", "/all não existe suborno. Apenas a captura da atenção, com uma forma monetaria", "/all Na teoria o comunismo funciona, na teoria", "/all Lembre-se, vc nunca seráum completo inútil,vc sempre pode servir de mau exemplo", "/all Relacionamentos são construídos sobre diamantes e Viagra", "/all Quem gosta de mulher feia é salão de beleza", "/all É mais facil pedir desculpa do que pedir licença", "/all Quando digo 'Eu entendo', não significa que eu concorde. Não significa que eu compreendo. Não significa nem que estou ouvindo", "/all Se álcool não fosse bom, não terminava com cool", "/all Camisinha não é uma caixa de cereal. Você não lê a embalagem enquanto está comendo", "/all Salve o planeta. Afinal, ele é o unico que tem cerveja", "/all O amor não é cego, é retardado", "/all Um dia pensei em parar de beber... foram os 20 piores segundos da minha vida", "/all As mulheres mais bonitas são sempre as mais solitárias", "/all Falam que o álcool causa a morte de muitas pessoas, mas nunca falam quantas pessoas nasceram por causa dele", "/all a energia gasta pedindo permissão é muito maior do que a pedindo desculpas", "/all Mulher feia é igual a Lua: poucos homens vão até lá, e logo querem voltar", "/all Aprendi que não importa oque você faça, mas com quem você faça", "/all Ás vezes o único jeito de realmente apreciar o que se tem é imaginar como sua vida seria sem isto", "/all A matemática, meu filho, nada mais é do que a irmã lésbica da biologia", "/all Quando estou ficando triste, eu paro de ficar triste e começo a ser incrível em vez disso. true story", "/all Mentira é apenas uma grande história que alguém estragou com a verdade", "/all Não se case antes dos 30 anos", "/all Não é lendário se os seus amigos não estiverem lá para ver", "/all Isso vai ser legen… (espere) dário!", "/all Há uma série de passos quando se trata de esquecer uma mulher… da cama dela até a porta", "/all Uma garota só pode ser louca em proporção direta ao seu nível de gostosura", "/all Natal é o tempo em que as pessoas estão solitárias e desesperadas, é a parte mais maravilhosa do ano", "/all Só existem duas razões para sair com uma garota com quem você já saiu antes: seios siliconados", "/all Fevereiro é o Danny DeVito dos meses", "Uma das 24 semelhanças entre as mulheres e os peixes é que ambos são atraídos por objetos brilhantes", "/all Jesus esperou três dias para voltar a vida. Foi perfeito! Se ele tivesse esperado apenas um dia, muitas pessoas nem teriam ouvido que ele tinha morrido" , "/all Nunca compre coisas vivas para uma mulher. Isso só as faz lembrar de bebês", "/all Álcool te rouba a capacidade de tomar decisões sensatas. Não queremos que seja você a perder essa habilidade e sim ela", "/all Sarcasmo é para vencedores", "/all Um cigarro encurta a vida em 2 minutos. Uma garrafa de álcool encurta a vida em 4 minutos. Um dia de trabalho encurta a vida em 8 horas", "/all Metrossexual é um gay que não consegue transar", "/all Existem pessoas que quando bebem demais, choram. O segredo é beber além desse ponto", "/all Cara legal é como você chama um amigo babaca e fracassado que teve que dançar com uma prima feia de uma garota bonita", "/all Sentimentos são como os seios de sua mãe, você sabe onde eles estão, mas é melhor não sentí-los", "/all não minta para as mulheres, apenas proteja-as da verdade", "/all Nunca é bom dizer às mulheres mais do que precisam saber, porque amamos as mulheres e queremos protegê-las. Uma mulher sem pistas é uma mulher feliz", "/all O álcool é um veneno, mas tem certas coisas dentro de nóes que precisamos matar as vezes", "/all O amor é a gasolina da vida... custa caro, acaba rapido e pode ser substituído pelo álcool", "/all as mulheres não podem olhar para um homem sem pensar em como vão mudá-lo", "/all A primeira impressão é a que fica. Depois vamos moldando as inverdades", "/all Não se esqueça: se ouvir um click metálico, role no chão e corra em zigue-zague", "/all Quer uma dica para curar a ressaca? Nunca pare de beber", "Álcool é para os poucos que podem se dar ao luxo de ter poucos neurônios", "/all Os caçadores são a forma que a natureza tem para manter o seu equilibrio" , "/all Aviões não são como carros, você não pode pilotar um avião quando está bêbado", "/all Três frases para facilitar sua vida:Segura pra mim. Já estava assim quando eu cheguei. Bem pensado chefe", "/all Se você não faz parte da solução, faz parte do problema", "/all Se não pode ajudar, atrapalhe, o importante é participar", "/all Você pode ter todo o dinheiro do mundo, mas, há algo que você jamais poderá comprar: um dinossauro", "/all Mamãe querida, meu coração por ti bate... Como caroço de abacate", "/all A luz elétrica é mais útil que a luz do Sol, porque a luz do Sol ilumina só quando é dia, ou seja, quando não faz falta e a luz elétrica ilumina só de noite, quando está tudo escuro", "/all Sabe qual o animal que come com o rabo? Todos, porque eles não podem tirar o rabo para comer", "/all Não há luta pior do que aquela que se enfrenta", "/all Prefiro morrer do que perder a vida", "/all é bem difícil amar os inimigos, mas amar os idiotas é quase impossível", "/all A música se divide em 3 partes: mú-si-ca", "/allEm vez de dar a um político as chaves da cidade, seria melhor trocar as fechaduras", "/all Se o plano A não funcionar, não se preocupe. O alfabeto tem mais 26 letras pra você", "/all Quando a fome aperta, a vergonha afrouxa", "/all Se você é uma dessas pessoas que não tem sorte, quando vir a luz no fim do túnel...corra, pois é um trem", "/all Não deixes que nada te desanime, pois até um pé-na-bunda te empurra para a frente", "/all Não leve a vida tão a sério. Você nunca sairá vivo dela mesmo", "/all Não roube! O Governo não gosta de concorrência", "/all Desistir é para os fracos.Faça como eu, nem tente", "/all No dia que suor der dinheiro, pobre nasce sem sovaco", "/all Em briga de saci qualquer chute é uma voadora", "/all Se ferradura desse sorte burro nao puxava carroça", "/all Drogas fazem a gente perder a memória e uma outra coisa que não lembro", "/all Se o mundo fosse bom, bebê não nascia chorando", "/all 12 de junho é o dia dos namorados; os outros 364 são nossos", "/all Se você tem olho gordo, use colírio diet", "/all Evite a ressaca, mantenha-se bêbado", "/all Existem dois tipos de pessoas no mundo: as que sempre terminam as suas frases e as que...", "/all Peito de mulher é igual autorama, feito para as crianças, mas só os adultos brincam", "/all Parente quando vem para casa é como peixe: passando dos três dias começa a feder", "/all Deus criou o homem antes da mulher para não ouvir palpites" };

                            Random RandName = new Random();
                            string Temp2 = Tilt2[RandName.Next(0, Tilt2.Length)];

                            Core.DelayAction(() => Chat.Say(Temp2), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Player.DoEmote(Emote.Laugh);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        break;
                }
            }
        }
        


    }
}