using System;
// to creat region =>> Ctrl + S  Ctrl + K 
#region layout&ViweStart&ViweImport&TagHelper
/*
layout: الـ Layout هو القالب العام (template) اللي بيحط الهيكل المشترك للصفحات: رأس الصفحة (header)، قائمة تنقّل (nav), فوتر، ملفات CSS/JS المشتركة... وبعدين كل View خاصة بكل صفحة بتحط المحتوى الخاص بيها جوا المكان المخصص في الـ Layout. يعني بدل ما تكرر نفس الكود في كل صفحة، تعمل قالب واحد وتطلّع منه كل الصفحات.

ليه بنستخدم Layout؟

بتقلل التكرار (DRY).

تغيّر تصميم الموقع مرة واحدة بدل ما تعدّل كل صفحة.

بتحسن التنظيم والقراءة.

بتسهّل إدارة موارد ثابتة (css/js، meta tags). 
   ====================================================
ViweStart : هو ملف خاص موجود في مجلد Views، وظيفته إنه يحدد إعدادات مشتركة لكل الـ Views في المشروع — خصوصًا تحديد الـ Layout — من غير ما تكرر نفس الكود في كل View.
فوائد _ViewStart.cshtml
1️⃣ توفير الوقت وعدم التكرار

بدل ما تكتب Layout = ... في كل View، تكتبه مرة واحدة بس.

2️⃣ سهولة إدارة الـ Layout

لو حبيت تغير الـ Layout الأساسي → تغيّر سطر واحد بس.

3️⃣ إمكانية تخصيص Views معيّنة

أي View ممكن تتجاهل إعدادات ViewStart وتحدد Layout مختلف#endregion
   =================================================
ViweImport : Tag Helpers هي طريقة ASP.NET Core عشان تخلّي كود الـ HTML في الـ Views أسهل، أوضح، وأقرب للـ Frontend
TagHelper: هو ملف إعدادات عام للـ Views بيحدّد:

الـ Namespaces اللي عايز تعمل لها import

الـ Tag Helpers اللي عايز تفعّلها

الـ Directives الخاصة بالـ Razor
وبالتالي كل الـ Views جوّه نفس الفولدر ومجلداته الفرعية بتورث الإعدادات دي.
 */
#endregion

#region connect to dbcontext from Repo Or Controls
public DepartmentRepository()
{
    //// _dbcontext = new DemoDbContext();
    //every time new object of repository is created new object of dbcontext is created it's False Way xxxxx
    //Dependency Injection is the best way to handle dbcontext object using DI container CLR will manage the lifetime of dbcontext object
    //Scoped Lifetime is the best lifetime for dbcontext object
    //In ASP.NET Core we can register dbcontext in the service container in the Program.cs file
    //services.AddDbContext<DemoDbContext>(options => options.UseSqlServer("Server= .; Database=DemoDB;Trusted_Connection=true;"));
    //Then we can inject dbcontext in the repository constructor
}


#endregion
#region SingleOrDefault VS FirstOrDefault
//SingleOrDefault

//✔ عنصر واحد فقط
//✔ لو لقى 2 → Exception
//✔ مثالي للحقول الفريدة (Unique)

//FirstOrDefault

//✔ أول عنصر
//✔ حتى لو في 10 غيره
//✔ مناسب للبحث العادي
#endregion
============================
#region Find Vs Where
Find
✔ أسرع طريقة تجيب بيها عنصر
✔ لازم تستخدم Primary Key
✔ يشوف الكاش الأول ثم DB
✔ بيرجع أسرع من FirstOrDefault

 Where()؟

لما تبحث بشرط غير الـ ID

لما تتوقع نتائج متعددة

لما تعمل فلترة/Sorting/Includes 
	#endregion
============================
#region ChangeTracker VS NoTracking
✔ استخدم ChangeTracker لما:

بتعمل Update

بتعمل Delete

بتضيف Entity جديدة

بتعدل بيانات User/Order/Department

✔ استخدم AsNoTracking لما:

بتعرض بيانات فقط (Read Only)

بتعمل تقارير

بترجع List كبيرة

API GET request

Dashboard فيها آلاف السجلات
#endregion
============================
#region Find Vs FirstOrDefault
		
المقارنة	                    Find	FirstOrDefault
يستخدم الـ PK فقط                	✔️	❌
يبحث في الذاكرة قبل DB	            ✔️	❌
يدعم أي شروط	                   ❌	✔️
يدعم Include	                   ❌	✔️
الأكثر سرعة للـ PK	               ✔️	❌

#endregion
============================
