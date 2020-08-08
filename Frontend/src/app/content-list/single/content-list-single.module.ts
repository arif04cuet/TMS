import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentListSingleComponent } from './content-list-single.component';
import { NzPageHeaderModule } from 'ng-zorro-antd';

@NgModule({
    declarations:[
        ContentListSingleComponent
    ],
    exports:[
        ContentListSingleComponent
    ],
    imports:[
        CommonModule,
        NzPageHeaderModule

    ],
    providers:[

    ]
    
})
export class ContentListSingleModule {}