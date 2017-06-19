// Modules //
import * as Raven from 'raven-js';
import { FormsModule } from '@angular/forms';
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { UniversalModule } from 'angular2-universal';

// Components //
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProductFormComponent } from './components/product-form/product-form.component';

// Services //
import { ProductService } from "./services/product.service";
import { AppErrorHandler } from "./app.error-handler";
import { ProductListComponent } from './components/product-list/product-list.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { ViewProductComponent } from './components/view-product/view-product.component';
import { PhotoService } from "./services/photo.service";
import { BrowserXhrWithProgress, ProgressService } from "./services/progress.service";
import { BrowserXhr } from "@angular/http";
import { AuthService } from "./services/auth.service";

// Config sentry.io //
Raven
    .config('https://097efc9d5ced432398c904a59f8d66a6@sentry.io/174916')
    .install();

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProductFormComponent,
        ProductListComponent,
        PaginationComponent,
        ViewProductComponent
    ],
    imports: [
        FormsModule,
        ToastyModule.forRoot(),
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'products/new', component: ProductFormComponent },
            { path: 'products/edit/:id', component: ProductFormComponent },          
            { path: 'products/:id', component: ViewProductComponent },
            { path: 'products', component: ProductListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: BrowserXhr, useClass: BrowserXhrWithProgress },
        AuthService,
        ProductService, 
        PhotoService,
        ProgressService
    ]
})
export class AppModule {
}
