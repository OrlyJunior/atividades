﻿namespace MVC3.Interfaces
{
    public interface ICrud<T>
    {
        bool salvar(T t);
        bool editar(T t);
        void deletar(T t);
        List<T> consultar();
    }
}
