
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


/*PROTECTED REGION ID(usingRentACarGen.ApplicationCore.CEN.RentACar_Coche_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarGen.ApplicationCore.CEN.RentACar
{
public partial class CocheCEN
{
public int New_ (RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum p_categoria)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Coche_new__customized) START*/

        CocheEN cocheEN = null;

        int oid;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Categoria = p_categoria;

        //Call to CocheRepository

        oid = _ICocheRepository.New_ (cocheEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
