## Phases

### Phase I

* alle Views
* View Bindings an View Models
* Navigation
* Note Typ
* "Dummy" NoteService mit Fixen Daten

**Endtermin** : Freitag Morgen ca 1100  
**Ergebnis** : Komplett Navigierbare App

### Phase II

* NoteDataAccess
* NoteService mit DataAccess kommunizieren lassen

**Endtermin** : Freitag Morgen ca 1130  
**Ergebnis** : App mit der möglichkeit Daten hinzu zu fügen und zu löschen

### Phase III

* Zu Favoritenhinzufügen
* Anzeige des Favoriten Flag auf der MasterPage

**Endtermin** : Freitag Mittag ca 1430  
**Ergebnis** : Favoriten setzen und diese mit Priorität in der Liste anzeigen

### Phase IV

* PhotoService
* Anbindung PhotoService an Detail und Edit Page

**Endtermin** : Freitag Nachmittag 1600  
**Ergebnis** : Bild zu einer Notiz hinzufügen können und diese bei Bedarf ändern.

### Phase V

* Rey Appicon

**Endtermin** : Freitag Nachmittag: 1630  
**Ergebnis** : App mit Rey Logo.



## ToDo's

* Models
  * **NotesDataAccess** (15m)
    * SQLite Implementation mit Save/Update/Delete Methoden
  * **NotesService** (30m)
    * Stellt alle Notes zur Verfügung und deren Methoden
      * Update
      * Delete
      * Favoritisieren
  * **NotesUpdatedEventArgs** (15min)
    * Event Args für den Event, welcher die ViewModels über changes informiert
  * **Note** (15min)
    * DTO mit Fields
      * Id
      * Title
      * Text
      * DateCreated
      * DateEdited
      * (Optional) Photo
      * (Optional) IsFavorite
  * (Optional) **PhotoService** (2h)
    * Speichert und gibt das Bild der Notiz
* ViewModels
  * **NotesMasterViewModel** (1h)
    * Navigation auf Child
    * Delete Item
    * Add New Item
    * Sortierung der Notizen nach IsFavorite --> DateEdited
    * Subscribe auf Changes von Service
  * **NotesDetailViewModel** (1h)
    * Beim Display Daten von Service beziehen
    * Delete Item
    * (Optional) Favoritisieren
    * Edit Button & Navigation
    * Subscribe auf Changes von Service
  * **NotesEditViewModel** (1h)
    * Save Item
    * Navigation Back verwirft Changes
    * Edit Felder 
* Views
  * **NotestMasterView** (1h 30m)
    * Darstellung aller Notes in einer Liste sortiert nach Favorite(true/false) --> DateEdited
    * Add New Button in NavBar rechts
    * LongPress um Löschoption einzublenden
  * **NotesDetailView** (30m)
    * Darstellung Title / Text / (Optinal)Photo im Readonly Modus
    * Delete Button
    * Edit Button
    * (Optional)Fav Button
  * **NotesEditView** (30m)
    * Darstellung Title / Text / (Optinal)Photo Felder im Edit Modus
    * Save Button
* Nicht Funktionale Anforderungen
  * App Icon Rey Banner (30m)
