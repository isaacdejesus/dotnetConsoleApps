﻿
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace mathgameMauiWindows.Models
{
    [Table("game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameOperation Type { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }
    public enum GameOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}
