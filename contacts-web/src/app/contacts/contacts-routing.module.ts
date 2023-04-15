import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './pages/list/list.component';
import { UpsertComponent } from './pages/upsert/upsert.component';
import { SearchComponent } from './pages/search/search.component';
import { ContactComponent } from './pages/contact/contact.component';
import { LayoutComponent } from './pages/layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'list',
        component: ListComponent,
      },
      {
        path: 'create',
        component: UpsertComponent,
      },
      {
        path: 'edit/:id',
        component: UpsertComponent,
      },
      {
        path: 'search',
        component: SearchComponent,
      },
      {
        path: ':id',
        component: ContactComponent,
      },
      {
        path: '**',
        redirectTo: 'list',
      },
    ],
  },
  {
    path: '**',
    redirectTo: '404',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContactsRoutingModule {}
