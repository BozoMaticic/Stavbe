import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';

import { authGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { StavbeListComponent } from './stavbe/stavbe-list/stavbe-list.component';
import { StavbaDetailComponent } from './stavbe/stavba-detail/stavba-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { StavbaEditComponent } from './stavbe/stavba-edit/stavba-edit.component';
// import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
// import { memberDetailedResolver } from './_resolvers/member-detailed.resolver';
// import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
// import { adminGuard } from './_guards/admin.guard';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {path: 'stavbe', component: StavbeListComponent},
            {path: 'stavbe/:naziv', component: StavbaDetailComponent},
            {path: 'stavba/edit', component: StavbaEditComponent,
                canDeactivate: [preventUnsavedChangesGuard]}, 

            {path: 'members', component: MemberListComponent},
            {path: 'members/:username', component: MemberDetailComponent, 
                // resolve: {member: memberDetailedResolver}
            },
            {path: 'member/edit', component: MemberEditComponent, 
                canDeactivate: [preventUnsavedChangesGuard]},
            {path: 'lists', component: ListsComponent},
            {path: 'messages', component: MessagesComponent},
            // {path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard]}
        ]
    },
    {path: 'errors', component: TestErrorsComponent},
    {path: 'not-found', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', component: HomeComponent, pathMatch: 'full'}
];


//     canDeactivate: [preventUnsavedChangesGuard]},
