﻿import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);

// to restart the application when changes are made in the source code
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(() => {
        // before restarting the application, create a new app element, which replaces the old one
        const oldRootElem = document.querySelector('app');
        const newRootElem = document.createElement('app');
        oldRootElem!.parentNode!.insertBefore(newRootElem, oldRootElem);
        platform.destroy();
    });
}