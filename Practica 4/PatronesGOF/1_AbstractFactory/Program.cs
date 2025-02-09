using PatronesGOF.AbstractFactory;

var catalogoGasolina = new Catalogo(new FabricaGasolina());
var catalogoElectrico = new Catalogo(new FabricaElectrico());

catalogoElectrico.MostrarVehiculos();
catalogoGasolina.MostrarVehiculos();