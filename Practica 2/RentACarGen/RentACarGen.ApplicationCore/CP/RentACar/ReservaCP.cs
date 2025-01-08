
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;
using RentACarGen.ApplicationCore.CEN.RentACar;
using RentACarGen.ApplicationCore.Utils;



namespace RentACarGen.ApplicationCore.CP.RentACar
{
public partial class ReservaCP : GenericBasicCP
{
public ReservaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ReservaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
