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
        public T[][] State { get; private set; }

        public BoardState(T[][] initialState)
        {
            State = initialState;
        }

        /// <summary>
        /// Get a hash code regarding all the values in the State.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            var hash = new HashCode();

            // Combine hash codes of all elements in the matrix
            foreach (var row in State)
            {
                foreach (var val in row)
                {
                    hash.Add(val.GetHashCode());
                }
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

        /// <summary>
        /// Get all the possible legal moves from the current board <see cref="State"/>.
        /// </summary>
        /// <returns>an enumerable of all possible moves from the current <see cref="State"/></returns>
        public abstract IEnumerable<BoardState<T>> GetPossiblesMoves();
    }
}
