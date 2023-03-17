using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid guid)
        {
            Guid = guid;
        }
        public Guid Guid { get; private init; }

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(obj.GetType() != this.GetType())
            {
                return false;
            }

            if(obj is not Entity entity)
            {
                return false;
            }

            return entity.Guid == Guid;
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if(other.GetType() != this.GetType())
            {
                return false;
            }

            return other.Guid == Guid;
        }

        public override int GetHashCode() 
        {
            return Guid.GetHashCode();
        }
    }
}
