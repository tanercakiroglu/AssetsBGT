using System;

namespace Assets.DO.Interface
{
    public interface IResponse
    {
        void PrepareException(Exception ex);
    }
}
