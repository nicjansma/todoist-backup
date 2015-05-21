Copyright (c) 2015 Nic Jansma
[http://nicj.net](http://nicj.net)

See [nicj.net](http://nicj.net/2009/06/11/todoistcom-and-todoistbackupexe) for a description of this project.

TodoistBackup uses your Todoist API token to backup your projects and tasks to an XML file.

# Instructions

1. Get your Todoist API token: Login, go to Preferences, and then to Account.  Your Web Service API token should be listed.

2. Run `TodoistBackup.exe`:

    `TodoistBackup.exe api-token output.xml [/completed] [/notes]`

* `api-token` is your Todoist API token
* `output.xml` is the output file you want to save to
* `/completed` will save all completed items (optional)
* `/notes` will save all item notes (optional)

# Version History

* v1.0 - 2009-06-11: Initial release
* v1.1 - 2011-12-02: Small fix for Todoist JSON change
* v1.1.1 - 2012-02-12: note_count field added to TodoistItem
* v1.2 - 2012-05-14: Gets Notes, added an option to skip completed items (thanks to Tomasz Z. Kosowski)
* v1.3 - 2012-08-07: Fixes for is_archived, archived_timestamp, archived_date and notes properties
* v1.4 - 2014-01-10: Additional properties saved, no longer crashes if new properties are added
* v1.5 - 2014-01-15: Only backs up notes and completed items if the command line arguments are set
* v1.6 - 2015-05-20: Switch to HTTPS for API calls
