import { Component } from '@angular/core';
import { TableComponent } from 'src/shared/table.component';
import { LibraryHttpService } from 'src/services/library-http-service';


@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent extends TableComponent {

 count = {
   libraryCount:10,
   bookCategoryCount:40,
   bookCount:3000
 }

  constructor(
    private libraryHttpService: LibraryHttpService) {
    super(libraryHttpService);
  }
  ngOnInit(): void {
    //this.gets();
  }

  registration()
  {
    this.goTo('/member-registration');
  }


}
