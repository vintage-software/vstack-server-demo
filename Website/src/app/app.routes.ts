import { Routes } from '@angular/router';

import { HomepageComponent } from './homepage/homepage.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NotesComponent } from './notes/notes.component';
import { NotebooksComponent } from './notebooks/notebooks.component';

export const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'about', component: AboutComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'notes', component: NotesComponent },
  { path: 'notebooks', component: NotebooksComponent },
];