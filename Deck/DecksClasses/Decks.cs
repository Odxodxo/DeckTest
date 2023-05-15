using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API_for_Cards.Models;
using Cards;

/*Необходимо разработать класс (либо RESTful сервис), предоставляющий интерфейс
• Создать именованную колоду карт (колода создаётся упорядоченной)
• Удалить именованную колоду
• Получить список названий колод
• Перетасовать колоду
• Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)

Необходимо спроектировать интерфейсы так, чтобы алгоритм перетасовки мог задаваться через
конфигурацию приложения (путём выбора из «простой» и «эмуляция перетасовки вручную»).
Необходимо самостоятельно спроектировать API для колоды и все типы данных.

Примечания:
• Колоды достаточно хранить в памяти, но подумать о том, как впоследствии работать с БД.
• Реализацию достаточно сделать для стандартной колоды игральных карт (52 штуки), но
будет плюсом при решении помнить о том, что сортировщику карт всё равно, какую
колоду тасовать.
• Алгоритм перетасовки достаточно реализовать «простой» (любой, самый быстрый в
реализации); при желании можно реализовать «эмуляцию перетасовки вручную» (колода
делится примерно посередине, части меняются местами, и так много раз).

При отправке решения, укажите, пожалуйста, сколько времени было потрачено

Разместите ссылку на Ваше решение в GitHub или GitLab*/
    public class Decks : IDecks
    {
        private static readonly Dictionary<string, Deck> DecksDict = new Dictionary<string, Deck>();
        private static IShuffleProvider<Card> shuffleProvider = new RandomShuffleProvider<Card>();

        public void Add(string name, int cardsAmount, string[] suit)
            => DecksDict.Add(name, new Deck(cardsAmount, suit));

        public void Add(string name)
        {
            if (DecksDict.Keys.Contains(name))
            {
                throw new Exception
                    ($"Deck with name {name} already Exist.");
            }
            
            DecksDict.Add(name, new Deck());
        }


    public void Remove(string name)
            => DecksDict.Remove(name);
        

        public Deck Get(string name)
        {
            if (!DecksDict.Keys.Contains(name))
            {
                throw new Exception($"Deck with name {name} not found")
                    ;
            }
            return DecksDict[name];
        } 
        

        public IEnumerable<string> GetDecksNames()
            => DecksDict.Keys.ToList();
        


        public void ShuffleDeck(string name)
            => DecksDict[name].DeckOfCards = new List<Card>(shuffleProvider.Shuffle(DecksDict[name].DeckOfCards));
        
        public void ChangeShuffle(string shuffleName)
        {
            switch (shuffleName)
            {
                case "Hand":
                    shuffleProvider = new HandShuffle<Card>();
                    break;
                default:
                    shuffleProvider = new RandomShuffleProvider<Card>();
                    break;
            }
        }
    }

    
   

