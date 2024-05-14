import { FieldValues, Path, ControllerRenderProps, ControllerFieldState, UseFormStateReturn, FieldPath, useController, UseControllerProps, UseControllerReturn, FieldError } from "react-hook-form";
import { Status, WarningRule, WarningValueType } from "./PowerController";
import React from "react";

type UsePowerControllerProps<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = UseControllerProps<TFeildValues, TName>
    & {
        warn?: WarningRule<WarningValueType<TFeildValues, TName>>[],
    }
type PowerFieldStateReturn<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = UseControllerReturn<TFeildValues, TName>['fieldState'] & { warning?: string };
type PowerFieldReturn<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = UseControllerReturn<TFeildValues, TName>['field'] & { status: Status };
type UsePowerControllerReturn<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = Omit<UseControllerReturn<TFeildValues, TName>, 'field' | 'fieldState'> & {
    field: PowerFieldReturn<TFeildValues, TName>,
    fieldState: PowerFieldStateReturn<TFeildValues, TName>
}

export const usePowerController = <TFieldValues extends FieldValues = FieldValues, TName extends FieldPath<TFieldValues> = FieldPath<TFieldValues>>(props: UsePowerControllerProps<TFieldValues, TName>): UsePowerControllerReturn<TFieldValues, TName> => {
    const controllerRes = useController(props);

    const warningBuilder = React.useCallback(
        (value: WarningValueType<TFieldValues, TName>) => (props.warn ?? [])
            .filter((warn) => warn.validator(value))
            .map(warn => warn.message)
            .at(0),
        [props.warn]
    );

    const statusBuilder = React.useCallback(
        (error: FieldError | undefined, value: WarningValueType<TFieldValues, TName>): Status => {
            if (error) return 'error';
            if (warningBuilder(value)) return 'warning';
        },
        [props.rules, props.warn]
    )

    return ({
        ...controllerRes,
        field: { ...controllerRes.field, status: statusBuilder(controllerRes.fieldState.error, controllerRes.field.value) },
        fieldState: {...controllerRes.fieldState, warning: warningBuilder(controllerRes.field.value)}
    })
}