import * as ko from 'knockout';
import 'knockout.validation';

import './login.scss';

class LoginViewModel {
    public readonly username: KnockoutObservable<string>;
    public readonly password: KnockoutObservable<string>;
    public readonly isFormValid: KnockoutComputed<boolean>;

    constructor() {
        this.username = ko.observable('').extend({ required: true });
        this.password = ko.observable('').extend({ required: true });
        this.isFormValid = ko.pureComputed(() => this.username.isValid() && this.password.isValid());
    }
}

ko.applyBindings(new LoginViewModel());