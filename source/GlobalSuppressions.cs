// <copyright file="GlobalSuppressions.cs" company="Nic Jansma">
//  Copyright (c) Nic Jansma 2014 All Right Reserved
// </copyright>
// <author>Nic Jansma</author>
// <email>nic@nicj.net</email>

//
// These CA warnings are suppressed because we're using an XML serializer for TodoistItem/TodoistProject, 
// so the properties must be public.  Since this isn't for a framework, we don't need to worry about these warnings.
//
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "TodoistBackup.TodoistItem.#Labels")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "TodoistBackup.TodoistItem.#Notes")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "TodoistBackup.TodoistProject.#Items")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "TodoistBackup.TodoistProject.#Items")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "TodoistBackup.TodoistItem.#Labels")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "TodoistBackup.TodoistItem.#Notes")]
