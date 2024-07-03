using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogo
{
    internal class Player
    {
        //atributos 
        private string _name;
        private int _score;
        private TimeSpan _gameTime;


        //metodos 
        public Player(string name)
        {
            Name = name;
            Score = 0;
            _gameTime = TimeSpan.FromSeconds(0);
        }

        // Propriedades
        public string Name
        {
            set
            {
                if (!String.IsNullOrEmpty(value))

                    _name = value;
            }
            get
            {
                return _name;
            }
        }
        public int Score
        {
            set
            {
                if (value >= 0)
                    _score += value;
            }
            get
            {
                return _score;
            }
        }
            
        public TimeSpan GameTime
        {
            get { return _gameTime; }
            set
            {
                _gameTime += value;
            }
        }

        public override string ToString()
        {
            return "nome:" + Name + "\nPontuação: " + Score + $"\nTempo de Partida: {GameTime:hh\\:mm\\:ss}";
        }
    }
}