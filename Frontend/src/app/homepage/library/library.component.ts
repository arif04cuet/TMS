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
   libraryCount:0,
   bookategoryCount:0,
   bookCount:0
 }
data=[1,2];

  constructor(
    private libraryHttpService: LibraryHttpService) {
    super(libraryHttpService);
  }
  ngOnInit(): void {
    this.get();
  }

  get() {
    this.loading = true;
    
      this.subscribe(this.libraryHttpService.getCounts(),
        (res: any) => {
          this.count = res.data;
          this.loading = false;
        }
      );
    
  }

  registration()
  {
    this.goTo('/member-registration');
  }


}
