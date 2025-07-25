using MassTransit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain
{

    public abstract class Entity<T> where T : IEquatable<T>
    {
        protected Entity()
        {
            CreatedAt = DateTime.UtcNow;
            Id = typeof(T) == typeof(Guid) ? (T)(object)NewId.NextSequentialGuid() : default(T)!;
        }
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator != (Entity<T> left, Entity<T> right) => !(left == right);
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            if (object.ReferenceEquals(this,obj))
                return true;

            Entity<T> another = (Entity<T>)obj;
            return another.Id.Equals(Id);
        }
        public static bool operator == (Entity<T> left, Entity<T> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right.Id);
        }
      

    }
}
