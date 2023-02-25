using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleStates
{
    /// <summary>
    /// The base class for a board state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BoardState<T> : IEquatable<BoardState<T>> where T : IEquatable<T>
    {
        /// <summary>
        /// The state of the board.
        /// </summary>
        public T[,] State { get; private set; }

        public BoardState(T[,] initialState)
        {
            State = initialState;
        }

        #region IEquatable
        /// <summary>
        /// Get a hash code regarding all the values in the State.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            var hash = new HashCode();

            // Combine hash codes of all elements in the matrix
            foreach (var val in State)
            {
                hash.Add(val.GetHashCode());
            }

            return hash.ToHashCode();
        }

        public bool Equals(BoardState<T>? other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is null)
            {
                return false;
            }
            return GetHashCode() == other.GetHashCode();
        }

        public static bool operator ==(BoardState<T> left, BoardState<T> right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(BoardState<T> left, BoardState<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if(obj is not BoardState<T> other){
                return false;
            }
            return GetHashCode() == other.GetHashCode();
        }

        #endregion IEquatable

        /// <summary>
        /// Get all the possible legal moves from the current board <see cref="State"/>.
        /// </summary>
        /// <returns>an enumerable of all possible moves from the current <see cref="State"/></returns>
        public abstract IEnumerable<BoardState<T>> GetPossibleMoves();

        /// <summary>
        /// Find the first occurence of a value in the board.
        /// </summary>
        /// <param name="value">The value to find</param>
        /// <returns>a tuple of row and col of the first occurence of the <paramref name="value"/>. (-1,-1) if not found.</returns>
        protected (int row, int col) FindPositionofValueInBoard(T value)
        {
            for (int i = 0; i < State.GetLength(0); i++)
            {
                for (int j = 0; j < State.GetLength(1); j++)
                {
                    if (State[i, j].Equals(value))
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // Value not found in matrix
        }
    }
}
