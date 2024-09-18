using FirstWeb.Data;
using FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public IActionResult Index() // to generate view, Right-click and click add view -> razor view 
        {
            //var objCategoryList = _dbContext.Categories.ToList(); // same as select * in sql
            IEnumerable <Category> objCategoryList = _dbContext.Categories; // var to IEnumerable and removing the ToList()
            // _dbContext.Categories, retrieve's data
            return View(objCategoryList);
        }
        // Get
        public IActionResult Create() 
        {
            return View();
        }
        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("CustomError","Parehas and duha <3"); // Custome validation error
                ModelState.AddModelError("Name", "custome name error, and name kay base sa category na model or class"); // Custom validation error, but the error message in model shoudl be removed
            }
            if (ModelState.IsValid) { // SERVER SIDE VALIDATION
                _dbContext.Add(obj);
                _dbContext.SaveChanges(); // Pushes the "obj" or the datas in the database
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); // Go to index action   
                //return RedirectToAction("Index", "Category"); // If this "index" is in other controller then pass the name of the controller in second parameter
            }
            return View(obj);
        }
        public IActionResult Edit(int? id) // using the ? symbol in C#, you make a value type nullable, allowing it to hold either a value or null. This feature is especially useful when you need to represent optional or missing data in your applications.
        {
            if (id == null || id == 0) { 
                return NotFound();
            }
            // else retrieved the data with the correspnding id

            //var categoryFirst = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingle = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            var categoryFind = _dbContext.Categories.Find(id); // find uses primary to retrieve data
            if (categoryFind == null) {
                return NotFound();
            }
            return View(categoryFind);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            var existingCategory = _dbContext.Categories.Find(obj.Id);

            Console.WriteLine($"Category Id: {obj.Id}");
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Parehas and duha <3"); // Custome validation error
                ModelState.AddModelError("Name", "custome name error, and name kay base sa category na model or class"); // Custom validation error, but the error message in model shoudl be removed
            }
            if (ModelState.IsValid)
            {
                try
                {

                    // Update only the fields that need to be changed
                    existingCategory.Name = obj.Name;
                    existingCategory.DisplayOrder = obj.DisplayOrder;
                    existingCategory.MyProperty = obj.MyProperty;
                    existingCategory.CreatedDateTime = obj.CreatedDateTime;



                    //_dbContext.Categories.Update(obj);// THIS DOES NOT WORK!
                    _dbContext.SaveChanges(); // This line may throw an exception if the update fails


                    TempData["success"] = "Category Updated Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    // Log the error (could be done with a logger)
                    Console.WriteLine(e); // For debugging purposes
                                          // Return a user-friendly error message
                    ModelState.AddModelError(string.Empty, "Unable to update category. Try again, and if the problem persists, see your system administrator. "
                        + obj.Name + " Huh!");
                }
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFind = _dbContext.Categories.Find(id);
            if (categoryFind == null)
            {
                return NotFound();
            }
            return View(categoryFind);
        }
        // Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDataHandler(Category obj) // Parameter can also be " int? "
        {
            var toBeDeleteData = _dbContext.Categories.Find(obj.Id);
            if (toBeDeleteData == null) {
                return NotFound();
            }
            _dbContext.Remove(toBeDeleteData);
            _dbContext.SaveChanges();

            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
