import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { Declarations } from './core/configs/declaration.config';
import { Providers } from './core/configs/provider.config';
import { Imports } from './core/configs/import.config';


@NgModule({
  declarations: Declarations,
  imports: Imports,
  providers: Providers,
  bootstrap: [AppComponent]
})
export class AppModule { }
