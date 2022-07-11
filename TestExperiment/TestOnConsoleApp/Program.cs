// See https://aka.ms/new-console-template for more information

using TestOnConsoleApp.Models;

Console.WriteLine("Hello, World!");




CarHireContext hireContext = new CarHireContext();




//try
//{


//    var myBranch = hireContext.Branches
//                                .Include(bb => bb.Cars)
//                                .ThenInclude(cc => cc.CarModel)
//                                .ToList();

//    foreach (var item in myBranch)
//    {
//        Console.WriteLine(item.AddressId);

//        foreach (var mycar in item.Cars)
//        {
//            Console.WriteLine(mycar.CarModel.ModelName);
//        }
//    }


//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.InnerException.Message);
//}


//try
//{


//    var myCarBrands = hireContext.CarBrands
//                                .Include(bb => bb.CarModels)
//                                .ToList();

//    foreach (var item in myCarBrands)
//    {
//        Console.WriteLine(item.Name);

//        foreach (var mycar in item.CarModels)
//        {
//            Console.WriteLine(mycar.CarBrand.Name);
//        }
//    }


//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.InnerException.Message);
//}


//CarModel carModel = new CarModel();

//try
//{
//    var branch = new Branch();

//    branch.BranchName = "";

//    hireContext.Set<Branch>().Add(branch);
//    await hireContext.SaveChangesAsync();

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.InnerException.Message);
//}



Console.WriteLine("Finished");








